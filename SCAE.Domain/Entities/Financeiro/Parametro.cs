using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("parametro", Schema = "financeiro")]
    public class Parametro : IEntity
    {
        private ParametroCRMVendas _parametroCRMVendas;
        private ParametroControleAgua _parametroControleAgua;

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? CentroCustoReceitalId { get; set; }
        public CentroCusto CentroCustoReceita { get; set; }
        public int? ContaGerenciaReceitalId { get; set; }
        public ContaGerencial ContaGerencialReceita { get; set; }
        public decimal JurosAditamento { get; set; }
        public decimal DescontoAditamento { get; set; }
        public int? TipoAmortizacaoId { get; set; }
        public TipoAmortizacao TipoAmortizacao { get; set; }
        public decimal JurosAmortizacao { get; set; }
        public ValoresAdicionais ValoresAdicionaisParcela { get; set; }
        public bool DesmarcarBoletosCobrancasAutomaticas { get; set; }

        public ParametroCRMVendas ParametroCRMVendas
        {
            get
            {
                if (_parametroCRMVendas == null)
                {
                    _parametroCRMVendas = new ParametroCRMVendas();
                }
                return _parametroCRMVendas;
            }
            private set
            {
                _parametroCRMVendas = value;
            }
        }

        public ParametroControleAgua ParametroControleAgua
        {
            get
            {
                if (_parametroControleAgua == null)
                {
                    _parametroControleAgua = new ParametroControleAgua();
                }
                return _parametroControleAgua;
            }
            private set
            {
                _parametroControleAgua = value;
            }
        }

        public ICollection<ParametroGatway> Gatways { get; set; }
        public ICollection<ParametroCobranca> Cobrancas { get; set; }

        public Parametro()
        {
            Gatways = new List<ParametroGatway>();
            Cobrancas = new List<ParametroCobranca>();
            ValoresAdicionaisParcela = new ValoresAdicionais();
            //ParametroCRMVendas = new ParametroCRMVendas();
        }

    }
    [Owned]
    public class ParametroCRMVendas
    {
        private int _diasExpiracaoPreReserva;
        private int _diasExpiracaoReserva;

        public int DiasExpiracaoPreReserva
        {
            get
            {
                if (_diasExpiracaoPreReserva <= 0)
                {
                    _diasExpiracaoPreReserva = 30;
                }
                return _diasExpiracaoPreReserva;
            }
            private set
            {
                _diasExpiracaoPreReserva = value;
            }
        }

        public int DiasExpiracaoReserva
        {
            get
            {
                if (_diasExpiracaoReserva <= 0)
                {
                    _diasExpiracaoReserva = 30;
                }
                return _diasExpiracaoReserva;
            }
            private set
            {
                _diasExpiracaoReserva = value;
            }
        }
        public int DiasExpiracaoReajusteProposta { get; set; }
        public int DiasMinimosEntreReservaMesmoLead { get; set; }
        public decimal PercentualComissaoCorretor { get; set; }

        public int? CentroCustoComissaoCorretorId { get; set; }
        public CentroCusto CentroCustoComissaoCorretor { get; set; }
        public int? ContaGerencialComissaoCorretorId { get; set; }
        public ContaGerencial ContaGerencialComissaoCorretor { get; set; }

    }

    [Owned]
    public class ParametroControleAgua
    {
        public bool EmpresaPadraoBoletoAgua { get; set; }
        public int? CentroCustoControleAguaId { get; set; }
        public CentroCusto CentroCustoControleAgua { get; set; }
        public int? ContaGerencialControleAguaId { get; set; }
        public ContaGerencial ContaGerencialControleAgua { get; set; }
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public int? TipoOperacaoId { get; set; }
        public TipoOperacaoFinanceira TipoOperacao { get; set; }
        public int? TipoGatewayId { get; set; }
        public TipoGateway TipoGateway { get; set; }
    }
}
