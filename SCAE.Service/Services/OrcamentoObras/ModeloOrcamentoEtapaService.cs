using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Domain.Entities.OrcamentoObras;
using ObrasDomain = SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Services.Shared;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc.Routing;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class ModeloOrcamentoEtapaService : CrudService<ModeloOrcamentoEtapa, IModeloOrcamentoEtapaRepository>, IModeloOrcamentoEtapaService
    {
        private readonly IOrcamentoEtapaService _orcamentoEtapaService;
        private readonly IComposicaoService _composicaoService;
        private readonly IOrcamentoObrasService _orcamentoObrasService;
        public ModeloOrcamentoEtapaService(IModeloOrcamentoEtapaRepository repository, IOrcamentoEtapaService orcamentoEtapaService, IComposicaoService composicaoService, IOrcamentoObrasService orcamentoService) : base(repository)
        {
            _orcamentoEtapaService = orcamentoEtapaService;
            _composicaoService = composicaoService;
            _orcamentoObrasService = orcamentoService;
        }

        /// <summary>w
        /// Salva OrcamentoEtapa como ModeloOrcamentoEtapa
        /// </summary>
        /// <param name="orcamentoEtapaId">Id válido de OrcamentoEtapa no sistema</param>
        /// <param name="estadoId">Id válido de Estado no sistema</param>
        /// <returns></returns>
        public async Task SalvarComoModelo(int orcamentoEtapaId, int estadoId)
        {
            using (var transaction = BeginTransaction())
            {
                var modelo = await CriarModeloEtapa(orcamentoEtapaId, null, estadoId);
                await CriarModeloEtapasFilhas(modelo.Id, orcamentoEtapaId, estadoId);

                transaction.Commit();
            }
        }

        private async Task<ModeloOrcamentoEtapa> CriarModeloEtapa(int id, int? modeloEtapaPaiId, int estadoId)
        {
            var orcamentoEtapa = await _orcamentoEtapaService.GetAllNoTracking("Itens.Composicao").FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException("O id de OrçamentoEtapa inserido é inválido!");

            var modeloOrcamentoEtapa = new ModeloOrcamentoEtapa()
            {
                ModeloEtapaPaiId = modeloEtapaPaiId,
                Titulo = orcamentoEtapa.Titulo,
                Descricao = orcamentoEtapa.Descricao,
                Quantidade = orcamentoEtapa.Quantidade,
                OrigemId = id
            };

            foreach (var etapaItem in orcamentoEtapa.Itens)
            {
                var composicaoItem = etapaItem.Composicao;

                composicaoItem.Estado.AtualizarEstado(estadoId);

                var modeloComposicaoItem = new ModeloComposicao()
                {
                    Codigo = composicaoItem.Codigo,
                    Descricao = composicaoItem.Descricao,
                    UnidadeMedidaId = composicaoItem.UnidadeId,
                    ClasseId = composicaoItem.ClasseId,
                    OrigemId = composicaoItem.OrigemId,
                    Mes = composicaoItem.Mes,
                    Ano = composicaoItem.Ano,
                    ValorOriginalDesonerado = composicaoItem.ValorDesonerado,
                    ValorOriginalNaoDesonerado = composicaoItem.ValorNaoDesonerado //Enquanto está em fase de testes
                };

                var modeloEtapaItem = new ModeloOrcamentoEtapaItem()
                {
                    Quantidade = etapaItem.Quantidade,
                    Composicao = modeloComposicaoItem
                };

                modeloOrcamentoEtapa.Itens.Add(modeloEtapaItem);
            }

            await Post(modeloOrcamentoEtapa);

            return modeloOrcamentoEtapa;
        }

        private async Task CriarModeloEtapasFilhas(int modeloEtapaPaiId, int orcamentoEtapaPaiId, int estadoId)
        {
            var filhas = await _orcamentoEtapaService.GetAllNoTracking("Itens.Composicao").Where(x => x.EtapaPaiId == orcamentoEtapaPaiId)?.ToListAsync();

            if (filhas.IsNullOrEmpty())
                return;

            foreach (var filha in filhas)
            {
                var modeloFilha = await CriarModeloEtapa(filha.Id, modeloEtapaPaiId, estadoId);
                await CriarModeloEtapasFilhas(modeloFilha.Id, filha.Id, estadoId);
            }

            return;
        }

        public async Task<ModeloOrcamentoEtapa> GetMenorIdNoTracking(string include)
        {
            var menorId = await GetAllNoTracking().MinAsync(x => x.Id);
            return await GetAllNoTracking("ModeloEtapaPai, Itens.Composicao").FirstAsync(x => x.Id == menorId);
        }

        public async Task PostList(List<ModeloOrcamentoEtapa> list, bool saveChanges = true)
        {
            await _repository.InsertList(list);

            if (saveChanges)
                await _repository.SaveChangesAsync();
        }

        public async Task<ModeloOrcamentoEtapa> GetTreeViewNoTracking(int id)
        {
            var modeloEtapa = await GetAllNoTracking("Itens.Composicao.Classe, Itens.Composicao.UnidadeMedida").FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException("O id de ModeloOrcamentoEtapa inserido é inválido!");

            modeloEtapa.Children = await GetFilhasTreeViewNoTracking(id);

            return modeloEtapa;
        }

        public async Task<List<ModeloOrcamentoEtapa>> GetTreeViewNoTracking()
        {
            var modelosEtapa = await GetAllNoTracking("Itens.Composicao.Classe, Itens.Composicao.UnidadeMedida").Where(x => !x.ModeloEtapaPaiId.HasValue).ToListAsync()
                ?? throw new NotFoundException("Nenhum modelo de OrcamentoEtapa encontrado!");

            foreach (var modelo in modelosEtapa)
                modelo.Children = await GetFilhasTreeViewNoTracking(modelo.Id);

            return modelosEtapa;
        }

        private async Task<List<ModeloOrcamentoEtapa>> GetFilhasTreeViewNoTracking(int modeloEtapaPaiId)
        {
            var etapasFilhas = await GetAllNoTracking("Itens.Composicao.Classe, Itens.Composicao.UnidadeMedida").Where(x => x.ModeloEtapaPaiId.Value == modeloEtapaPaiId).ToListAsync();
            foreach (var etapaFilha in etapasFilhas)
                etapaFilha.Children = await GetFilhasTreeViewNoTracking(etapaFilha.Id);

            return etapasFilhas;
        }

        /// <summary>
        /// Retorna o Id do orcamento salvo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orcamentoModelo"></param>
        /// <param name="etapaPaiId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<int> AplicarModelo(int id, ObrasDomain.OrcamentoObras orcamentoModelo, int? etapaPaiId)
        {
            if (orcamentoModelo.Id < 1)
                await _orcamentoObrasService.Post(orcamentoModelo);

            var modelo = await GetAllNoTracking("Itens.Composicao").Where(x => x.Id == id).FirstOrDefaultAsync()
                ?? throw new NotFoundException("O id de ModeloOrcamentoEtapa inserido é inválido!");

            modelo.Children = await GetFilhasTreeViewNoTracking(id);

            var orcamento = await _orcamentoObrasService.GetAllNoTracking().Where(x => x.Id == orcamentoModelo.Id).FirstOrDefaultAsync()
                ?? throw new NotFoundException("O id de OrcamentoObras inserido é inválido!");

            var dataArray = orcamento.Referencia.Split("/");
            var mes = Int32.Parse(dataArray[0]);
            var ano = Int32.Parse(dataArray[1]);

            //Criar Etapa
            var orcamentoEtapa = new OrcamentoEtapa()
            {
                Titulo = modelo.Titulo,
                Descricao = modelo.Descricao,
                Quantidade = modelo.Quantidade,
                Itens = await GerarItens(modelo.Itens, mes, ano), //É preciso considerar não apenas a sinapi, implementar depois
                EtapaPaiId = etapaPaiId,
                OrcamentoId = orcamentoModelo.Id,
            };

            await _orcamentoEtapaService.Post(orcamentoEtapa);

            //Criar Filhas
            foreach (var modeloFilha in modelo.Children)
            {
                await AplicarModelo(modeloFilha.Id, orcamentoModelo, orcamentoEtapa.Id);
            }

            return orcamentoModelo.Id;
        }

        private async Task<List<OrcamentoEtapaItem>> GerarItens(ICollection<ModeloOrcamentoEtapaItem> collection, int mes, int ano)
        {
            //Por enquanto sempre considerando a sinapi
            var list = collection.ToList();
            var itens = new List<OrcamentoEtapaItem>();

            foreach (var modeloItem in list)
            {
                var modeloComposicao = modeloItem.Composicao;
                var composicaoId = 0;

                if (modeloComposicao.OrigemId == OrigemDados.Sinapi.Id)
                {
                    composicaoId = await _composicaoService.GetAllNoTracking()
                                                            .Where(x => x.Codigo == modeloComposicao.Codigo && x.Mes == mes && x.Ano == ano)
                                                            .Select(x => x.Id)?.FirstOrDefaultAsync();
                }
                else
                {
                    composicaoId = await _composicaoService.GetAllNoTracking()
                                                            .Where(x => x.Codigo == modeloComposicao.Codigo && x.Descricao == modeloComposicao.Descricao)
                                                            .Select(x => x.Id)?.FirstOrDefaultAsync();
                }

                if (composicaoId < 1)
                    throw new BadRequestException($"Não foi possível encontrar a composição {modeloComposicao.Codigo} correspondente ao contexto do orçamento atual");

                var item = new OrcamentoEtapaItem()
                {
                    Quantidade = modeloItem.Quantidade,
                    ComposicaoId = composicaoId,
                };

                itens.Add(item);
            }

            return itens;
        }

        //private async Task GerarFilhas(int etapaPaiId)
        //{

        //}

    }

}