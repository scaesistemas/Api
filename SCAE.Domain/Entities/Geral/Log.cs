using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("log", Schema = "geral")]
    public class Log : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public DateTime DataHora { get; set; }
        [Required] public string Descricao { get; set; }
        [Required] public string Usuario { get; set; }
        [Required] public int RegistroId { get; set; }
        [Required] public string Controle { get; set; }

        public Log()
        {
            DataHora = DateTime.Now;
        }
    }
}
