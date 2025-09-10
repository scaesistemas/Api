using SCAE.Domain.Entities.Geral;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain
{
    public class Arquivo
    {
        [StringLength(255)] public string Nome { get; set; }
        public decimal Tamanho { get; set; }
        [StringLength(255)] public string Tipo { get; set; }
        public byte[] Dados { get; set; }
        [NotMapped] public bool Excluido { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
