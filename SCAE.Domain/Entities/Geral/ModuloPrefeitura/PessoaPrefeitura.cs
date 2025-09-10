using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
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
    [Table("pessoaprefeitura", Schema = "geral")]
    public class PessoaPrefeitura : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Required] public string Nome { get; set; }

        [Required]
        public Moradia Moradia
        {
            get;
            set;
        }
        [StringLength(18), Required] public string CnpjCpf { get; set; }
        [StringLength(15)] public string Telefone { get; set; }
        [StringLength(15)] public string Celular { get; set; }
        [StringLength(120)] public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }
        [StringLength(15)] public string Rg { get; set; }
        [StringLength(15)] public string OrgaoExpedido { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public Qualificacao Qualificacao { get; set; }
        [Required]public Conjuge Conjuge { get; set; }
        public Bancario Bancario { get; set; }

        public int FamiliarProblemaCronico { get; set; }
        public bool BeneficioGov {  get; set; }
        public string TipoBeneficioGov { get; set; }
        public int IdososFamilia { get; set; }
        public bool DisponibilidadeFinanciamento { get; set; }
        public bool InteresseRegularizacaoFundiaria { get; set; }
        public bool PessoaAtiva { get; set; }

        public int? TipoMoradioNovaId {  get; set; }
        public TipoMoradiaNova TipoMoradiaNova { get; set; }

        public bool PossuiVulnerabilidadeSocial { get; set; }
        public bool ReceberInformacoesEmailCelular { get; set; }
        public bool DivulgacaoProgramaSocial { get; set; }

        public bool PossuiImovelExterno { get; set; }
        public int QuantImoveisExterno { get; set; }

        public int? IdImportacaoPessoa { get; set; }
        public RegistroImportacao RegistroImportacao { get; set; }

        public bool possuiInteresseMoradiaNova { get; set; }
        public bool PossuiPreferenciaPorLocalizacao { get; set; }
        public string PreferenciaPorLocalizacao { get; set; }
        public bool PossuiNecessidadesEspeciais { get; set; }
        public string NecessidadesEspeciais { get; set; }
        public bool PossuiInteresseMelhoriaHabitacional { get; set; }
        public string InteresseMelhoriaHabitacional { get; set; }
        public decimal? TamanhoDesejadoNovaMoradia { get; set; }

        public ICollection<PessoaPrefeituraContato> Contatos { get; set; }
        public ICollection<PessoaPrefeituraDocumento> Documentos { get; set; }
        public ICollection<PessoaPrefeituraGateway> Gateways { get; set; }
        public ICollection<PessoaPrefeituraFamiliar> Familiares { get; set; }


        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int? CodigoOrigem { get; set; }

        public string DFourSignFolderId { get; set; }

        public string NomeCnpjCpf => $"{Nome} - {CnpjCpf}";
        public string CpfCnpjLimpo => StringHelper.LimparCpfCnpj(CnpjCpf);
        public decimal RendaBrutaTotal => Qualificacao?.RendaBruta ?? 0 + Conjuge?.RendaBruta ?? 0 + Familiares?.Sum(x=>x.RendaBruta) ?? 0; 
        [NotMapped]public bool NaoValidarCPF {  get; set; }

        public PessoaPrefeitura()
        {
            Moradia = new Moradia();
            Conjuge  = new Conjuge();
            Bancario = new Bancario();
            RegistroImportacao = new RegistroImportacao();
            Qualificacao = new Qualificacao();
            Documentos = new List<PessoaPrefeituraDocumento>();
            Gateways = new List<PessoaPrefeituraGateway>();
            Contatos = new List<PessoaPrefeituraContato>();
            Familiares = new List<PessoaPrefeituraFamiliar>();
        }

    }
}
