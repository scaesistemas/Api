using System.Collections.Generic;
using System.Linq;

namespace SCAE.Domain.Models.Financeiro
{

    public class KPIUniversalModel 
    {
        public KPITotalRecebiveisModel kPITotalRecebiveisModel { get; set; } = new KPITotalRecebiveisModel();
        public KPIDisponibilidadeLoteModel kPIDisponibilidadeLoteModel { get; set; } = new KPIDisponibilidadeLoteModel();
        public List<KPIAditamentosModel> kPIAditamentosModels { get; set; } = new List<KPIAditamentosModel>();
        public List<KPIVendidosCorretorModel> kPIVendidosCorretorModels { get; set; } = new List<KPIVendidosCorretorModel>();
        public KPIVendasContratoModel kPIVendasContratoModel { get; set; }

        public int AditamentoTotal => kPIAditamentosModels.Sum(x => x.Quantidade);



    }


    public class KPIQuantidadesModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public KPIQuantidadesModel(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }
    }

    public class KPIAditamentosModel
    {
        public KPIAditamentosModel(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }

    public class KPIVendidosCorretorModel
    {
        public KPIVendidosCorretorModel(string nome, int quantidadeVendido, int vendasCanceladas)
        {
            Nome = nome;
            QuantidadeVendido = quantidadeVendido;
            VendasCanceladas = vendasCanceladas;
        }

        public string Nome { get; set; }
        public int QuantidadeVendido { get; set; }
        public int VendasCanceladas { get; set; }
    }

    public class KPIDisponibilidadeLoteModel
    {
        public int QuantidadeVendidos { get; set; }
        public int QuantidadeDisponiveis { get; set; }
        public int QuantidadeReservados { get; set; }
        public int QuantidadeInvadidos { get; set; }
        public int QuantidadePenhorados { get; set; }
        public int QuantidadeIndisponiveis { get; set; }
    }

    public class KPITotalRecebiveisModel
    {
        public decimal ValorReceber { get; set; }
        public decimal ValorRecebido { get; set; }
        public decimal ValorTotal { get; set; }

    }

    public class KPIVendasContratoModel
    {
        public int? ContratosEmAndamento { get; set; }
        public int? ContratosQuitados { get; set; }
        public int? ContratosCancelados { get; set; }
        public int? ContratosNovos { get; set; }
        public int? LotesVendidos { get; set; }
    }

    public class KPISituacaoReguaCobrancaModel
    {
        public int? ContratosAditados { get; set; }
        public int? ContratosEmPrejuizo { get; set; }
        public int? ContratosJuridico { get; set; }
        public int? ContratosCobranca { get; set; }

    }

    
}
