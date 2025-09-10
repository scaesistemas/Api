using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cl_contratos_imagens")]
    public class ContratoImagem
    {
        [Column("idImagem")] public int Id { get; set; }
        [Column("idContrato")] public int ContratoId { get; set; }
        public int Sequencia { get; set; }
        public string Arquivo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
