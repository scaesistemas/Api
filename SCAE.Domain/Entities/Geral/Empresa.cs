using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("empresa", Schema = "geral")]
    public class Empresa : PessoaBase
    {
        private byte[] _logo;
        public EmpresaResponsavel Responsavel { get; set; }
        [Required] public EmpresaDocumento Documento { get; set; }

        public int? TipoEmpresaId { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }

        public byte[] Logo { get {return null; } set {_logo = value; } }

        public bool GerarZoop { get; set; }
        public bool GerarHokma { get; set; }
        public ICollection<EmpresaGateway> Gateways { get; set; }
        public ICollection<EmpresaArquivo> Documentos { get; set; }

        public int? SelfieResponsavelId { get; set; }
        public EmpresaArquivoUnico SelfieResponsavel { get; set; }
        public int? FotoDocumentoResponsavelId { get; set; }
        public EmpresaArquivoUnico FotoDocumentoResponsavel { get; set; }
        public int? VersoDocumentoResponsavelId { get; set; }
        public EmpresaArquivoUnico VersoDocumentoResponsavel { get; set; }
        public int? ContratoSocialLtdaId { get; set; }
        public EmpresaArquivoUnico ContratoSocialLtda { get; set; }

        public string TipoDocumentoResponsavel { get; set; }
        public string SiteDaEmpresa { get; set; }
        public decimal? RendaMensal {  get; set; }

        public BancoInfo BancoInfoEmpresa { get; set; }

        public Empresa() : base()
        {
            GerarZoop = true;
            BancoInfoEmpresa = new BancoInfo();
            Gateways = new List<EmpresaGateway>();
            Documentos = new List<EmpresaArquivo>();
            Documento = new EmpresaDocumento();
            Responsavel = new EmpresaResponsavel();
        }

        public Empresa(PessoaBase pessoa, EmpresaResponsavel responsavel) : base(pessoa)
        {
            Id = 0;
            Responsavel = responsavel;
            GerarZoop = true;
        }

        public byte[] GetFoto()
        {
            return _logo;
        }
    }
}
