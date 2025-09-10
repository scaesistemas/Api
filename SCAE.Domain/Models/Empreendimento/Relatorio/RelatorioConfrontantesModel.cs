using SCAE.Domain.Entities.Empreendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioConfrontantesModel
    {
        public List<ConfrontanteEmpreendimentoModel> Empreendimentos {  get; set; }
        public int QuantidadeEmpreendimentos => Empreendimentos?.Count ?? 0;

        public RelatorioConfrontantesModel()
        {
            Empreendimentos = new List<ConfrontanteEmpreendimentoModel>();
        }
    }

    public class ConfrontanteEmpreendimentoModel
    {
        public string Nome {  get; set; }
        public string EmpresaNome { get; set; }
        public List<ConfrontanteGrupoModel> Grupos { get; set; }
        public int QuantidadeGrupos => Grupos?.Count ?? 0;
        public ConfrontanteEmpreendimentoModel()
        {
            Grupos = new List<ConfrontanteGrupoModel> ();
        }
    }
    public class ConfrontanteGrupoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ConfrontanteUnidadeModel> Unidades { get; set; }
        public int QuantidadeUnidades => Unidades?.Count ?? 0;

        public ConfrontanteGrupoModel()
        {
            Unidades = new List<ConfrontanteUnidadeModel>();
        }
    }
    public class ConfrontanteUnidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? Area { get; set; }
        public decimal Valor { get; set; }
        public string FrenteNome { get; set; }
        public decimal Frente { get; set; }
        public string FundoNome { get; set; }
        public decimal Fundo { get; set; }
        public string LadoEsquerdoNome { get; set; }
        public decimal LadoEsquerdo { get; set; }
        public string LadoDireitoNome { get; set; }
        public decimal LadoDireito { get; set; }
        public string EmpreendimentoNome { get; set; }

    }
}
