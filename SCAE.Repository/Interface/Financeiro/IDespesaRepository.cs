using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Financeiro
{
    public interface IDespesaRepository : ICrudRepository<Despesa>
    {
        IQueryable<DespesaParcela> GetParcelaAll(string include = "");
        Task<List<DespesaParcela>> GetParcelaAllByCentroCustoAsNoTracking(int centroCustoId, string include = "");
        Task<List<DespesaParcela>> GetParcelaAllByContaGerencialAsNoTracking(int contaGerencialId, string include = "");
        IQueryable<DespesaParcela> GetParcelaAllAsNoTracking(string include = "");
        IQueryable<DespesaParcela> GetParcelaAllNoInclude();
        Task<DespesaParcela> GetParcelaByIdAsync(int id, string include = "");
        Task<DespesaParcela> GetParcelaByIdTrakingAsync(int id, string include = "");
        Task RemoveParcela(int id);
        void UpdateParcela(DespesaParcela parcela);
        void UpdateBaixa(DespesaBaixa baixa);
        IQueryable<DespesaClassificacao> GetClassificacaoAll();
        IQueryable<DespesaBaixa> GetBaixaAll(string include = "");
        IQueryable<DespesaBaixa> GetBaixaAllNoInclude();
        Task<DespesaBaixa> GetBaixaByIdTrakingAsync(int id);
        Task<List<DespesaDocumento>> GetDocumentos(int despesaId);
        Task<DespesaDocumento> GetDocumentoByIdAsync(int id);
        Task<DespesaClassificacao> GetClassificacaoByIdAsync(int id, string include = "");
        Task RemoveClassificacao(int id);
        Task RemoveDocumento(int id);
        Task<object> GetBaixas(int parcelaId);
        Task<List<DespesaParcela>> GetParcelasByContaGerencial(int[] empresaId, int contaGerencial, int tipo, DateTime anoInicio, DateTime anoFim);
        Task<List<DespesaParcela>> GetParcelasByCentroCusto(int[] empresaId, int centroCusto, int tipo, DateTime anoInicio, DateTime anoFim);
        Task<List<DespesaParcela>> ObterParcelas(int? empreendimentoId, int? despesaOrigemId, int centroCustoId, int contaGerencialId, char? contaGerencialTipo,
            DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
            DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int? formaPagamentoId,int? contaCorrenteId);

        IQueryable<DespesaParcela> ObterParcelasDetalhadas(int[] empreendimentoId, int? numeroContrato, int? formaPagamento, int? usuarioBaixa, int? fornecedorId, int[] situacaoParcelaId, int? contratoId, int[] tipoDespesaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
    DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int[] empresaId, int[] tipoAditamentoId, int? despesaId, string numeroDocumento, int[] centroCustoId, int[] contaGerencialId, int? contaCorrenteId);
        IQueryable<DespesaParcela> ObterParcelasDetalhadas(int[] empreendimentoId, int? numeroContrato, int? formaPagamento, int? usuarioBaixa, int? fornecedorId, int[] situacaoParcelaId, int? contratoId, int[] tipoDespesaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, int[] anos, int[] meses,
                                    int[] empresaId, int[] tipoAditamentoId, int? despesaId, string numeroDocumento, int[] centroCustoId, int[] contaGerencialId, int? contaCorrenteId, bool filtrarVencimento, bool filtrarPagamento);

        Task InsertList(List<Despesa> list);
        void UpdateList(List<Despesa> list);
        void RemoveList(List<Despesa> list);
        void UpdateListParcela(List<DespesaParcela> list);
        IQueryable<DespesaParcela> RelatorioComissoesCorretor(int corretorId, int[] empreendimentoIds, DateTime? dataContratoInicial, DateTime? dataContratoFinal);
        Task<bool> NumeroDocumentoDuplicado(Despesa despesa);

        IQueryable<DespesaParcela> PainelDespesaRelatorio(int[] empresaId, int[] empreendimentoId);

        IQueryable<DespesaBaixa> ObterBaixasDespesa(int[] empresaId, int[] empreendimentoId);
        IQueryable<DespesaClassificacao> GetClassificacoesByCentroCusto(int centroCustoId, string include="");
        IQueryable<DespesaParcela> GetParcelasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal);
        IQueryable<DespesaParcela> GetAllParcelasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, DateTime? DataEmissaoInicial, DateTime? DataEmissaoFinal, DateTime? DataBaixaInicial, DateTime? DataBaixaFinal);
        IQueryable<DespesaParcela> GetAllParcelasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? DataEmissaoInicial, DateTime? DataEmissaoFinal, int[] anos, int[] meses, bool filtrarVencimento, bool filtrarPagamento);
        IQueryable<DespesaBaixa> GetBaixasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal);
        List<DespesaParcela> FiltrarParcelasRelatorio(List<DespesaParcela> parcelas, int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal);
        List<DespesaBaixa> FiltrarBaixasRelatorio(List<DespesaBaixa> baixas, int[] empreendimentoIds, int[] empresaIds, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal);
        IQueryable<DespesaClassificacao> GetClassificacoesByContaGerencial(int contaGerencialId, string include = "");
    }
}
