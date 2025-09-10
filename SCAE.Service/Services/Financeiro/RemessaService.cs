using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;
using System;
using System.Threading.Tasks;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;

namespace SCAE.Service.Services.Financeiro
{ 
    public class RemessaService : CrudService<Remessa, IRemessaRepository>, IRemessaService
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly IBoletoService _boletoService;
        
        public RemessaService(IRemessaRepository repository, IContaCorrenteService contaCorrenteService,IBoletoService boletoService) : base(repository)
        {
            _contaCorrenteService = contaCorrenteService;
            _boletoService = boletoService;
        }

        
        public override async Task Post(Remessa entity)
        {
            var transacoes = entity.Transacoes;
            entity.Transacoes = null;

            using (var transaction = BeginTransaction())
            {

                await base.Post(entity);

                foreach (var transacao in transacoes) 
                {
                    transacao.RemessaId = entity.Id;
                    _repository.ModifiedTransacao(transacao);
                }


                var contaCorrente = await _contaCorrenteService.GetTracking(entity.ContaCorrenteId);
                contaCorrente.RemessaSequencia++;
                await SaveChangesAsync();

                transaction.Commit();
            }

        }

        public async Task<ArquivoRemessaDocumento> SalvarEProcessar(Remessa entity, EnumTipoArquivo enumTipoArquivo)
        {
            await Post(entity);
            return await Processar(entity.Id,enumTipoArquivo);
        }

        public async Task<ArquivoRemessaDocumento> Processar(int remessaId, EnumTipoArquivo enumTipoArquivo)
        {
            var remessa = await GetTracking(remessaId, "ContaCorrente.Banco, Documento,Transacoes.Parcela");

            if (remessa == null)
                throw new NotFoundException("Remessa não encontrada");

            if (remessa.Documento != null)
                throw new BadRequestException("Arquivo da remessa já foi processado");

            var arquivoRemessa = await _boletoService.RemessaBoleto(remessa.ContaCorrente.Banco.Codigo, remessa.Id,enumTipoArquivo);

            remessa.Documento = arquivoRemessa;
            remessa.IsProcessado = true;

            foreach(var transacao in remessa.Transacoes)
            {
                transacao.DataRemessa = DateTime.Now;
                transacao.Parcela.DataRemessa = DateTime.Now;
            }

            await SaveChangesAsync();

            return arquivoRemessa;
        }
    }
}
