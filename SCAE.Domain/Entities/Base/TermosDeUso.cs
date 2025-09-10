using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Base
{
    [Table("termosdeuso", Schema = "base")]
    public class TermosDeUso : IEntity
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string TermoString { get; set; }
        public int? TipoTermoEmpresaId { get; set; }
        public TipoTermoEmpresa TipoTermoEmpresa { get; set; }
    }
}
