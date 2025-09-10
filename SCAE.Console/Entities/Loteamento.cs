using SCAE.Framework.Helper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cl_loteamentos")]
    public class Loteamento
    {
        [Column("idLoteamento")] public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        
        public string RGI { get; set; }
        public string Processo { get; set; }
        public string Matricula { get; set; }
        public string LegalizacaoOrgao { get; set; }

        public string InfraEstrutura { get; set; }
        public decimal AreaRuas { get; set; }
        public decimal AreaLotes { get; set; }
        public decimal AreaTotal { get; set; }
        public ICollection<Quadra> Quadras { get; set; }

        public string CepFormatado => StringHelper.FormataCep(Cep);
    }
}
