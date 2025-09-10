using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using SCAE.Domain.Models.Financeiro;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;
using SCAE.Domain.Entities.Projeto;

namespace SCAE.Service.Services.Financeiro
{
    public class ReguaCobrancaService : CrudService<ReguaCobranca, IReguaCobrancaRepository>, IReguaCobrancaService
    {

        private readonly IReceitaRepository _receitaRepository;

        public ReguaCobrancaService(IReguaCobrancaRepository repository, IReceitaRepository receitaRepository) : base(repository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task DeleteEtapa(int EtapaId)
        {
            await _repository.ExcluirEtapa(EtapaId);
            await SaveChangesAsync();
        }

        public async Task<ReguaCobrancaModel> GetReguaCobranca(int id, int page, int pageSize = 10)
        {

            var contratos = (from p in _receitaRepository.GetParcelaDeContratoEmAberto().ToList()
                             group p by new { p.Receita.Contrato.Id, p.Receita.Contrato.Numero, p.Receita.Contrato.Sequencia } into g
                             select new ReguaCobrancaEtapaContratoModel
                             {
                                 Id = g.Key.Id,
                                 Numero = $"{g.Key.Numero}-{g.Key.Sequencia}",
                                 QuantidadeParcela = g.Count(),
                                 ParcelaMaisAntiga = g.Min(p => p.DataVencimento),
                                 ValorTotalParcela = Math.Round(g.Sum(x => x.Saldo), 2),
                                 EmpreendimentoNome = g.FirstOrDefault().Receita.Contrato.Empreendimento.Nome,
                                 QuadraNome = g.FirstOrDefault().Receita.Contrato.UnidadePrincipal.Grupo.Nome,
                                 UnidadeNome = g.First().Receita.Contrato.UnidadePrincipal.Nome
                             }).ToList();

            var reguaContrato = await Get(id, "Etapas");

            if (reguaContrato == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            var reguaContratoModel = new ReguaCobrancaModel(reguaContrato.Id, reguaContrato.Nome);



            foreach (var etapa in reguaContrato.Etapas)
            {
                var vencimentoInicial = DateTime.Today.AddDays(etapa.MaximoDiasVencido * -1);
                var vencimentoFinal = DateTime.Today.AddDays(etapa.MinimoDiasVencido * -1);

                var etapaModel = new ReguaCobrancaEtapaModel()
                {
                    Nome = etapa.Nome,
                    MinimoDiasVencido = etapa.MinimoDiasVencido,
                    MaximoDiasVencido = etapa.MaximoDiasVencido,
                    Contratos = contratos.Where(x =>
                           x.ParcelaMaisAntiga >= vencimentoInicial && x.ParcelaMaisAntiga <= vencimentoFinal).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                };

                reguaContratoModel.Etapas.Add(etapaModel);
            }
            return reguaContratoModel;
        }  
        public async Task<ReguaCobrancaModel> GetReguaCobrancaById(int id)
        {
             
            var contratos = (from p in _receitaRepository.GetParcelaDeContratoEmAberto().ToList()
                             group p by new { p.Receita.Contrato.Id, p.Receita.Contrato.Numero, p.Receita.Contrato.Sequencia } into g
                             select new ReguaCobrancaEtapaContratoModel
                             {  
                                 Id = g.Key.Id,
                                 Numero = $"{g.Key.Numero}-{g.Key.Sequencia}",
                                 QuantidadeParcela = g.Count(),
                                 ParcelaMaisAntiga = g.Min(p => p.DataVencimento),
                                 ValorTotalParcela = Math.Round(g.Sum(x => x.Saldo), 2),
                                 EmpreendimentoNome = g.FirstOrDefault().Receita.Contrato.Empreendimento.Nome,
                                 QuadraNome = g.FirstOrDefault().Receita.Contrato.UnidadePrincipal.Grupo.Nome,
                                 UnidadeNome = g.First().Receita.Contrato.UnidadePrincipal.Nome,
                                 SituacaoContrato = g.First().Receita.Contrato.Situacao.Nome,
                                 ClienteNome = g.First().Receita.Cliente.Nome
                             }).ToList();

            var reguaContrato = await Get(id, "Etapas");

            if (reguaContrato == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            var reguaContratoModel = new ReguaCobrancaModel(reguaContrato.Id, reguaContrato.Nome);



            foreach (var etapa in reguaContrato.Etapas)
            {
                var vencimentoInicial = DateTime.Today.AddDays(etapa.MaximoDiasVencido * -1);
                var vencimentoFinal = DateTime.Today.AddDays(etapa.MinimoDiasVencido * -1);

                var etapaModel = new ReguaCobrancaEtapaModel()
                {
                    Nome = etapa.Nome,
                    MinimoDiasVencido = etapa.MinimoDiasVencido,
                    MaximoDiasVencido = etapa.MaximoDiasVencido,
                    Contratos = contratos.Where(x =>
                           x.ParcelaMaisAntiga >= vencimentoInicial && x.ParcelaMaisAntiga <= vencimentoFinal).ToList()

                };

                reguaContratoModel.Etapas.Add(etapaModel);


            }


            return reguaContratoModel;
        }


    } 
}
