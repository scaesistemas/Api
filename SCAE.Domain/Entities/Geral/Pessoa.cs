using Microsoft.EntityFrameworkCore;
using SCAE.Domain;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral
{
    [Table("pessoa", Schema = "geral")]
    public class Pessoa : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [Required]public PessoaJuridicaResponsavel JuridicaResponsavel { get; set; }
        [StringLength(100), Required] public string Nome { get; set; }
        [StringLength(100)] public string Fantasia { get; set; }
        public int TipoPessoaId { get; set; }
        //public Moradia Moradia { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        [StringLength(18), Required] public string CnpjCpf { get; set; }
        [StringLength(15)] public string InscricaoMunicipal { get; set; }
        [StringLength(15)] public string InscricaoEstadual { get; set; }
        public Endereco Endereco { get; set; }
        [StringLength(15)] public string Telefone { get; set; }
        [StringLength(15)] public string Telefone2{ get; set; }
        [StringLength(120)] public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }
        [StringLength(15)] public string Rg { get; set; }
        [StringLength(15)] public string OrgaoExpedido { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public string Creci { get; set; }

        public Qualificacao Qualificacao { get; set; }
        [Required]public Conjuge Conjuge { get; set; }
        public Bancario Bancario { get; set; }

        public int FamiliarProblemaCronico { get; set; }
        public bool BeneficioGov {  get; set; }
        public int IdososFamilia { get; set; }

        public bool IsCliente { get; set; }
        public bool IsFornecedor { get; set; }
        public bool IsProprietario { get; set; }
        public bool IsCorretor { get; set; }
        public bool IsSeguradora { get; set; }
        public bool IsAdministradora { get; set; }
        public bool IsConstrutora { get; set; }
        public bool IsTransportadora { get; set; }

        //public bool PossuiImovelExterno { get; set; }
        //public int QuantImoveisExterno { get; set; }

        [MaxLength(45)] public string CodigoZoop { get; set; }

        public BancoInfo BancoInfoPessoa {get; set;}

        public ICollection<PessoaContato> Contatos { get; set; }
        public ICollection<PessoaDocumento> Documentos { get; set; }
        public ICollection<PessoaGateway> Gateways { get; set; }
        public ICollection<PessoaFamiliar> Familiares { get; set; }
        public ICollection<EmpreendimentoPessoa> EmpreendimentosPessoas { get; set; }

        public int? SelfieDocumentoId { get; set; }
        public PessoaArquivoUnico SelfieDocumento { get; set; }
        public int? FotoDocumentoPessoaId { get; set; }
        public PessoaArquivoUnico FotoDocumentoPessoa { get; set; }
        public int? VersoDocumentoPessoaId { get; set; }
        public PessoaArquivoUnico VersoDocumentoPessoa { get; set; }
        public int? ComprovanteResidencialId { get; set; }
        public PessoaArquivoUnico ComprovanteResidencial { get; set; }

        public string TipoDocumentoPessoa { get; set; }
        public string SiteDaPessoa { get; set; }
        public decimal? RendaMensal {  get; set; }


        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int? CodigoOrigem { get; set; }

        public string DFourSignFolderId { get; set; }

        public string NomeCnpjCpf => $"{Nome} - {CnpjCpf}";
        public string CpfCnpjLimpo => StringHelper.LimparCpfCnpj(CnpjCpf);
        public decimal RendaBrutaTotal => Qualificacao?.RendaBruta ?? 0 + Conjuge?.RendaBruta ?? 0 + Familiares?.Sum(x=>x.RendaBruta) ?? 0; 
        [NotMapped]public bool NaoValidarCPF {  get; set; }

        public Pessoa()
        {
            DataCadastro = DateTime.Now;
            BancoInfoPessoa = new BancoInfo();
            Endereco = new Endereco();
            Conjuge  = new Conjuge();
            Bancario = new Bancario();
            Qualificacao = new Qualificacao();
            Documentos = new List<PessoaDocumento>();
            Gateways = new List<PessoaGateway>();
            Contatos = new List<PessoaContato>();
            Familiares = new List<PessoaFamiliar>();
            EmpreendimentosPessoas = new List<EmpreendimentoPessoa>();
            JuridicaResponsavel = new PessoaJuridicaResponsavel();
        }  
    }

    
}
