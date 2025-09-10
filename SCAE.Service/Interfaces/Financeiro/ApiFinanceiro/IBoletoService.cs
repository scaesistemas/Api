using Microsoft.AspNetCore.Http;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro.ApiFinanceiro
{
    public interface IBoletoService
    {
        Task<ArquivoRemessaDocumento> RemessaBoleto(int codigoBanco, int remessaId, EnumTipoArquivo enumTipoArquivo);
        Task<List<RetornoModel>> RetornoBoleto(int codigoBanco, IFormFile arquivoRetorno, EnumTipoArquivo enumTipoArquivo);
        Task<string> VisualizarBoleto(int transacaoId);
        Task<string> VisualizarBoleto(int codigoBanco, BoletoModel boleto);
        BoletoModel ToModel(ReceitaTransacao transacao);
        Task<BoletoModel> MontarBoletoByTransacaoId(int transacaoId);
        Task<byte[]> VisualizarBoletoPdf(int codigoBanco, CarneModel boleto, bool manterNossoNumero);
    }
}
