using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Financeiro
{
    public interface IReceitaRepository : ICrudRepository<Receita>
    {
        IQueryable<ReceitaParcela> GetParcelaAll(string include = "");
        IQueryable<ReceitaTransacao> GetTransacaoAll(string include = "");
        IQueryable<ReceitaParcela> GetParcelaAllNoInclude();
        Task<ReceitaParcela> GetParcelaByCodigoGatewayAsync(string codigoGateway, string include);
        Task<ReceitaParcela> GetParcelaByIdAsync(int id);
        Task<ReceitaParcela> GetParcelaByIdAsync(int id, string include);
        Task<ReceitaParcela> GetParcelaByIdTrakingAsync(int id, string include = "");
        Task RemoveParcela(int id);
        Task RemoveTransacao(int id);
        void InsertParcela(ReceitaParcela parcela);
        void UpdateParcela(ReceitaParcela parcela);
        void UpdateListParcela(List<ReceitaParcela> list);
        void UpdateBaixa(ReceitaBaixa baixa);
        IQueryable<ReceitaClassificacao> GetClassificacaoAll();
        IQueryable<ReceitaBaixa> GetBaixaAllNoInclude(string include = "");
        Task<ReceitaBaixa> GetBaixaByIdTrakingAsync(int id);
        Task<ReceitaClassificacao> GetClassificacaoByIdAsync(int id);
        Task RemoveClassificacao(int id);
        Task<object> GetBaixas(int parcelaId);
        Task<List<ReceitaParcela>> GetParcelaByCentroCusto(int[] listaEmpresaId,int centroCusto, int tipo, DateTime anoInicio, DateTime anoFim);
        Task<List<ReceitaParcela>> GetParcelaByContaGerencial(int[] listaEmpresaId, int contaGerencial, int tipo, DateTime anoInicio, DateTime anoFim);
        Task<List<ReceitaParcela>> ObterParcelasFluxoCaixa(int[] empresaId, int tipo, DateTime anoInicio, DateTime anoFim);
        Task<List<ReceitaParcela>> ObterParcelas(int? empreendimentoId, int? tipoReceitaId, int centroCustoId, int contaGerencialId, char? contaGerencialTipo,
            DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
            DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int? formaPagamentoId,int? contaCorrenteId);

        IQueryable<ReceitaParcela> ObterParcelasDetalhadas(int[] empreendimentoId, int? numeroContrato, bool? pagamentoAutomatico, int? formaPagamento, int? usuarioBaixa, int? clienteId, int[] situacaoParcelaId, int? contratoId, int[] tipoReceitaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
           DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int[] empresaId, int[] tipoAditamentoId, int[] tipoServicoId, int? tipoContrato, int? tipoAmortizacao, int? grupoId, int? unidadePrincipalId);
        IQueryable<ReceitaBaixa> GetBaixasRelatorio(int[] empreendimentoId, int[] empresaId, int[] situacaoParcelaId, bool? isBaixaAutomatica, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal);

        // Relatório de SMS's enviados
        IQueryable<ReceitaParcela> GetRelatorioSmsEnviados(int[] empresaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal);

        IQueryable<ReceitaParcela> GetRelatorioWppEnviados(int[] empresaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal);

        IQueryable<ReceitaParcela> GetRelatorioCobrancas(int[] empresaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal);

        void InsertBaixaComprovante(ReceitaBaixaComprovante comprovantePagamento);
        void InsertAntecipacaoComprovante(AntecipacaoComprovante comprovante);
        void UpdateAntecipacaoComprovante(AntecipacaoComprovante comprovante);
        Task<ReceitaBaixa> GetBaixaByIdIncludeTrackingAsync(int id, string include = "");
        IQueryable<Receita> GetRelatorioContratosEmAtraso(int[] empreendimentoId, int? numeroContrato, int? mesesVencimentoInicio, int? mesesVencimentoFim, int? quantidadeParcelasMinima, int? quantidadeParcelasMaxima, int[] empresaId,int? diasVencimentoInicio, int? diasVencimentoFim);
        Task<AntecipacaoComprovante> GetAntecipacaoComprovanteByParcelaIdTrackingAsync(int parcelaId);
        IQueryable<AntecipacaoComprovante> GetAntecipacaoComprovanteAll();

        IQueryable<ReceitaParcela> ObterParcelasBoletoCobranca(int[] empreendimentoId, bool? boletoGerado, int? numeroContrato, bool? pagamentoAutomatico, int? clienteId, int[] tipoReceitaId, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
           int[] empresaId, int? sequenciaContrato, DateTime? dataCobrancaInicial, DateTime? dataCobrancaFinal, int[] loteId, int[] quadraId, int[] situacaoParcelaId, DateTime? dataBaixaInicial, DateTime? dataBaixaFinal);
        Task<int> ProximoNumero();
        IQueryable<ReceitaParcela> KPITotalRecebiveis(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal);
       IQueryable<ReceitaParcela> ReceitasPainelReceita(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal);
        IQueryable<ReceitaBaixa> BaixasPainelReceita(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal);
        IQueryable<ReceitaParcela> GetParcelaDeContratoEmAberto(DateTime? dataVencimentoMin, DateTime? dataVencimentoMax);
        IQueryable<ReceitaParcela> GetParcelaDeContratoEmAberto();

        Task<int> GetTotalParcelas(int parcelaId);
        Task RemoveBaixa(int id);
        void DetachedParcela(ReceitaParcela parcela);  
        decimal CalcularAmortizacaoPorQuantidadeParcela(int id, int quantidadeParcelas);
        IQueryable<ReceitaBaixa> GetRelatorioDimob(int[] situacaoContratoId, int[] empresasIds, int[] empreendimentosIds, string ano);
        IQueryable<ReceitaBaixa> ObterRelatorioEFD(int[] empresasIds, int[] empreendimentosIds, int? clienteId, string? ano, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal);  

        IQueryable<ReceitaParcela> GetParcelasRelatorioVgv(int[] empresasIds, int[] empreendimentosIds, int? ano);
        Task SetParcelasDiasPosVencimentoNaoReceberMax();
        Task SetDiasNegativacaoDefault();
        Task<bool> NumeroDocumentoDuplicado(string numeroDocumento);
        Task<int> ProximoNumeroParcela(int receitaId);

    }
}
