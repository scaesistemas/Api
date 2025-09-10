using SCAE.Framework.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class PessoaPrefeituraModel
    {
        [StringLength(100, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo ID Pessoa é obrigatório")]
        public int IdPessoa { get; set; }

        [StringLength(100, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres")]
        public string NomePai { get; set; }
        [StringLength(100, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres")]
        public string NomeMae { get; set; }

        [StringLength(120, ErrorMessage = "O valor do campo EmailPrincipal ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Email é obrigatório")]
        public string EmailPrincipal { get; set; }

        [StringLength(16, ErrorMessage = "O valor do campo Celular ultrapassou o limite de caracteres"), RequiredIf("PessoaFisica", "Não", ErrorMessage = "O campo Celular é obrigatório para pessoa jurídica")]
        public string Celular { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Telefone ultrapassou o limite de caracteres")]
        public string Telefone { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo CPF/CNPJ ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório")]
        public string CpfCnpj { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo RG ultrapassou o limite de caracteres")]
        public string RG { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Orgao Expedidor ultrapassou o limite de caracteres")]
        public string OrgaoExpedidor { get; set; }

        [Required(ErrorMessage = "O campo Data de Expedição é obrigatório"), RequiredIf("PessoaFisica", "Sim", ErrorMessage = "O campo Data da Expedicao é obrigatório para pessoa física")]
        public DateTime DataExpedicao { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Nacionalidade é obrigatório")]
        public string Nacionalidade { get; set; }

        public decimal RendaBruta { get; set; }
        public decimal RendaLiquida { get; set; }

        [RequiredIf("PessoaFisica", "Sim", ErrorMessage = "O campo Estado Civil é obrigatório para pessoa física")]
        public string EstadoCivil { get; set; }

        [StringLength(100, ErrorMessage = "O valor do campo ConjugeNome ultrapassou o limite de caracteres")]
        public string ConjugeNome { get; set; }

        [StringLength(14, ErrorMessage = "O valor do campo ConjugeCPF ultrapassou o limite de caracteres")]
        public string ConjugeCPF { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo ConjugeRG ultrapassou o limite de caracteres")]
        public string ConjugeRG { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo ConjugeOrgaoExpedidor ultrapassou o limite de caracteres")]
        public string ConjugeOrgaoExpedidor { get; set; }

        public DateTime ConjugeDataNascimento { get; set; }

        public decimal ConjugeRendaBruta { get; set; }

        public int FamiliarProblemaCronico { get; set; }
        public int IdososFamilia { get; set; }

        public string BeneficioGov { get; set; }
        public string PossuiInteresseMoradiaNova { get; set; }

        public string PossuiImovelExterno { get; set; }
        public int QuantImovelExterno { get; set; }

        public string PossuiInteresseMelhoriaHabitacional { get; set; }

        public string InteresseRegularizacaoFundiaria { get; set; }

        public string DisponibilidadeFinanciamento { get; set; }
        public decimal TamanhoDesejadoNovaMoradia { get; set; }

        public string PossuiPreferenciaPorLocalizacao { get; set; }

        [StringLength(250, ErrorMessage = "O valor do campo ultrapassou o limite de caracteres")]
        public string PreferenciaPorLocalizacao { get; set; }

        public string PossuiNecessidadesEspeciais { get; set; }
        public string PessoaAtiva { get; set; }
    }
}
