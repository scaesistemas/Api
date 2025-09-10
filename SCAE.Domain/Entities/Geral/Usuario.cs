using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("usuario", Schema = "geral")]
    public class Usuario : IEntity
    {
        private string _senha;
        private byte[] _foto;

        public int Id { get; set; }
        public int AssinanteId { get; set; }
        [MaxLength(120), Required] public string Login { get; set; }
        public string Senha { get { return null; } set { _senha = value; } }
        public Contato Complementar { get; set; }
        [Required] public DateTime DataHoraCriacao { get; set; }
        public byte[] Foto { get { return null; } set { _foto = value; } }
        [Required] public bool Ativo { get; set; }
        public bool PrimeiroAcesso { get; set; }
        public string Token { get; set; }
        public bool TemaEscuro { get; set; }

        public Permissoes[] Permissoes { get; set; }

        #region Corretor
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Atendimento> Atendimentos { get; set; }
        
        #endregion

        public Usuario()
        {
            DataHoraCriacao = DateTime.Now;
            Complementar = new Contato();
            PrimeiroAcesso = true;
            Ativo = true;
            Reservas = new List<Reserva>();
            Atendimentos = new List<Atendimento>();
        }

        public string GetSenha()
        {
            return _senha;
        }

        public byte[] GetFoto()
        {
            return _foto;
        }
    }
}
