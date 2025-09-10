using SCAE.Domain.Entities.Geral;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Shared
{
    public class SessionAppModel
    {
        public int AssinanteId { get; }
        public string AssinanteNome { get; }
        //public byte[] EmpresaLogo { get; set; }
        public int UsuarioId { get; }
        public string UsuarioNome { get; }
        public string Login { get; }
        public byte[] UsuarioFoto { get; set; }
        public bool TemaEscuro { get; set; }
        public int? ClienteId { get; set; }
        public Permissoes[] Permissoes {get;set;}

        public SessionAppModel(int usuarioId, string login, string usuarioNome, int assinanteId, string assinanteNome, int? clienteId)
        {
            UsuarioId = usuarioId;
            Login = login;
            UsuarioNome = usuarioNome;
            AssinanteId = assinanteId;
            AssinanteNome = assinanteNome;
            TemaEscuro = false;
            ClienteId = clienteId;
           // Permissoes = new List<Permissoes>();
        }
    }
}
