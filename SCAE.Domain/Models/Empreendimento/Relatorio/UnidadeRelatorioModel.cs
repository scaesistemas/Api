using SCAE.Domain.Entities.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioCompletoUnidade
    {
        public List<UnidadeRelatorioModel> ListaUnidades { get; set; } = new List<UnidadeRelatorioModel>();
        public TotalSituacaoUnidade TotaisSitucaoUnidades { get; set; } = new TotalSituacaoUnidade();
        public decimal TotalValor => ListaUnidades.Sum(x => x.Unidade.valor);
    }
    public class UnidadeRelatorioModel
    {
        public UnidadeModel Unidade { get; set; }
        public ContratoModel Contrato { get; set; }
    } 

    public class UnidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public int SituacaoId { get; set; }
        public string GrupoNome { get; set; }
        public EmpreendimentoModel Empreendimento { get; set; }
        public decimal valor {  get; set; }
        public decimal? x { get; set; }
        public decimal? y { get; set; }

    }

    public class TotalSituacaoUnidade
    {
        public int TotalUnidadeVendida { get; set; }
        public int TotalUnidadeDisponivel { get; set; }
        public int TotalUnidadeIndisponivel { get; set; }
        public int TotalUnidadeReservada { get; set; }
        public int TotalUnidadeInvadido { get; set; }
        public int TotalUnidadePenhorado { get; set; }
        public int TotalUnidadeCaucionado { get; set; }
    }


    public class ContratoModel
    {
        public int Id { get; set; }
        public int? UnidadeId { get; set; }
        public ICollection<ContratoUnidadeAdicional> UnidadesAdicionais { get; set; }
        public int Numero { get; set; }
        public ICollection<ContratoClienteModel> Clientes { get; set; }

        public ContratoModel()
        {
            Clientes = new List<ContratoClienteModel>();
        }
    }

    public class EmpreendimentoModel
    {
        public int Id { get; set; }
        public string EmpreendimentoNome { get; set; }

    }

    public class ContratoClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
