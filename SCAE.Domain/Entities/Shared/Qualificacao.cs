using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Domain
{
    public class Qualificacao
    {
        public int? ProfissaoId { get; set; }
        public Profissao Profissao { get; set; }
        public string ProfissaoExtra { get; set; }
        public int? EscolaridadeId { get; set; }
        public TipoEscolaridade Escolaridade { get; set; }
        public int? NacionalidadeId { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public int? NaturalidadeId { get; set; }
        public Municipio Naturalidade { get; set; }
        public int? EstadoCivilId { get; set; }
        public EstadoCivil EstadoCivil { get; private set; }
        public decimal? RendaBruta { get; set; }
        public decimal? RendaLiquida { get; set; }
        public string Susep { get; set; }
    }
}
