using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{

    public class RecebiveisProprietarioModel
    {
        public List<ProprietarioModel> Proprietarios { get; set; }

        public decimal TotalSocioPorcentagem { get; set; }
        public decimal TotalTaxaAdm => Proprietarios.Sum(x => x.TotalValorTaxaAdm);
        public decimal TotalRecebido => Proprietarios.Sum(x => x.TotalRecebido);

        public decimal TotalPercentual => Proprietarios.Sum(x => x.TotalPercentual);

        public int TotalParcela => Proprietarios.Sum(x => x.QtdeParcela);

        public decimal TotalPago => Proprietarios.Sum(x => x.TotalValorPago);

        public decimal TotalJuros => Proprietarios.Sum(x => x.TotalJuros);

        public decimal TotalDescontos => Proprietarios.Sum(x => x.TotalDescontos);

        public decimal TotalValorParcela => Proprietarios.Sum(x => x.TotalValorParcela);

        public RecebiveisProprietarioModel()
        {
            Proprietarios = new List<ProprietarioModel>();
        }
    }

    public class ProprietarioModel
    {
        public string Nome { get; set; }
        public decimal TotalPercentual => Parcelas.Sum(x => x.PercentualProprietario);
        public List<ParcelaProprietarioModel> Parcelas { get; set; }
        public decimal TotalValorTaxaAdm => Parcelas.Sum(x => x.ValorTaxaAdmMenosCorretor);
        public decimal TotalValorTaxaCorretor => Parcelas.Sum(x => x.ValorCorretor);
        public decimal TotalValorPago => Parcelas.Sum(x => x.ValorPagoParcela);
        public decimal TotalRecebido => Parcelas.Sum(x => x.ValorRecebido);

        public decimal TotalJuros => Parcelas.Sum(x => x.JurosParcelaBaixa + x.MultaParcelaBaixa);

        public decimal TotalDescontos => Parcelas.Sum(x => x.DescontoParcelaBaixa);

        public decimal TotalValorParcela => Parcelas.Sum(x => x.ValorParcela);

        public int QtdeParcela => Parcelas.Count();

        public ProprietarioModel()
        {
            Parcelas = new List<ParcelaProprietarioModel>(); 
        }
    }

    public class ParcelaProprietarioModel
    {
        public int ContratoNumero { get; set; }
        public int SequenciaNumero { get; set; }
        public string EmpresaNome { get; set; }
        public string ClienteNome { get; set; }
        public string NumeroSequenciaContrato => $"{ContratoNumero.ToString()}-{SequenciaNumero.ToString()}";
        public string ProprietarioNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; }
        public string UnidadeNome { get; set; }
        public int ParcelaNumero { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorPagoParcela { get; set; } 
        public decimal JurosParcelaBaixa { get; set; }
        public decimal MultaParcelaBaixa { get; set; }
        public decimal DescontoParcelaBaixa { get; set; }
        public DateTime VencimentoParcela { get; set; }
        public DateTime? DataPagamentoParcela { get; set; }
        public decimal PercentualProprietario { get; set; }
        public decimal PercentualAdministradora { get; set; }
        public decimal PercentualTotalCorretor { get; set; }
        public bool isTaxaCorretor { get; set;}
        public decimal ValorTaxaAdm => (ValorPagoParcela * PercentualAdministradora) / 100;
        public decimal ValorCorretor => (ValorPagoParcela * PercentualTotalCorretor) / 100;
        public decimal ValorTaxaAdmMenosCorretor => ((ValorPagoParcela - (isTaxaCorretor ? ValorCorretor : 0)) * PercentualAdministradora) / 100;
        public decimal ValorRecebido => ((ValorPagoParcela - ValorTaxaAdmMenosCorretor - (isTaxaCorretor ? ValorCorretor: 0)) * PercentualProprietario) / 100;
        public int ProprietarioId { get; set; }

        public decimal TaxaBoleto { get; set; }

        public decimal OutrasTaxas { get; set; }
    }
}

