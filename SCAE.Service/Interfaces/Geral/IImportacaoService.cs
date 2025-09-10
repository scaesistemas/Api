using Microsoft.AspNetCore.Http;
using SCAE.Data.Context;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral
{
    public interface IImportacaoService
    {
        void ChangeContextAll(ScaeApiContext context);
        Task<string> ImportarExcelContrato(IFormFile arquivo, int linhaInicial = 0);
        Task<string> ImportarAtualizacaoExcelContrato(IFormFile arquivo, int linhaInicial = 0, int? linhaFinal = 0);
        Task<string> ImportarExcelParcela(IFormFile arquivo, int linhaInicial = 0, int? linhaFinal = null, bool travarParcelasPrice = true, bool adaptarTotalParcelas = false);
        Task<string> ImportarExcelParcelaPrice(IFormFile arquivo, int linhaInicial = 0, int? linhaFinal = null, bool logParcelasJaExistentes = true, bool ordemCronologica = false);
        Task<string> ImportarExcelDespesaParcela(IFormFile arquivo, int usuarioId, int linhaInicial = 0, int? linhaFinal = null);
        Task<string> ExcluirExcelDespesas(IFormFile arquivo, int linhaInicial = 0);
        Task<string> ImportarExcelCentroCusto(IFormFile arquivo, int linhaInicial = 0);
        Task<string> ImportarExcelContaGerencial(IFormFile arquivo, int linhaInicial = 0);
        Task<string> LogParcelasDuplicadas(IFormFile arquivo, int linhaInicial = 0);
        Task<string> ImportarExcelEmpresa(IFormFile arquivo);
        Task<string> ImportarExcelPessoa(IFormFile arquivo, bool somenteCPFValido = true);
        Task<string> ImportarExcelPessoaPrefeitura(IFormFile arquivo, bool somenteCPFValido = true);
        Task<string> ImportarExcelFamiliaresPrefeitura(IFormFile arquivo);
        Task<string> ImportarExcelMoradiaPrefeitura(IFormFile arquivo);
        Task<string> ImportarExcelEmpreendimento(IFormFile arquivo);
        Task<string> ExcluirExcelEmpreendimento(IFormFile arquivo);
        Task<string> ImportarExcelUnidade(IFormFile arquivo);
        Task<string> ImportarExcelIndice(IFormFile arquivo);
        Task<string> ImportarClasseTipoSinapi(IFormFile arquivo);
        Task<string> ImportarInsumosSinapi(IFormFile arquivo, bool mesPrimeiro);
        Task<string> ImportarPlanilhaSinapi(IFormFile arquivo, bool mesPrimeiro);
        Task<string> AlterarExcelPessoa(IFormFile arquivo);
        Task<string> ExcluirExcelContrato(IFormFile arquivo, int linhaInicial = 0);
        Task<string> ImportarAtualizacoesUnidade(IFormFile arquivo);
        Task<string> ImportarExcelLead(IFormFile arquivo, int usuarioId);
    }

}
