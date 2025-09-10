using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class MoradiaPrefeituraModel
    {
        [Required(ErrorMessage = "O campo Pessoa Id é obrigatório")]
        public int IdPessoa { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEP ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string CEP { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo Logradouro ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Numero ultrapassou o limite de caracteres")]
        public string Numero { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Complemento ultrapassou o limite de caracteres")]
        public string Complemento { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Bairro ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [StringLength(2, ErrorMessage = "O valor do campo UF ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo UF é obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O campo Municipio é obrigatório")]
        public string Municipio { get; set; }
        public int NumeroComodos { get; set; }
        public int NumeroBanheiros { get; set; }
        public int NumeroOcupacoes { get; set; }
        public int NumeroFamiliaresImovel { get; set; }
        public int NumeroQuartos { get; set; }
        public string SituacaoRisco { get; set; }
        public string BeneficiarioFundiario { get; set; }
        public string FormaAquisicao { get; set; }
        public string AbastecimentoAgua { get; set; }
        public string TipoEnergia { get; set; }
        public string ColetaLixo { get; set; }
        public string Esgoto { get; set; }
        public string CondicaoMoradia { get; set; }
        public string Edificacao { get; set; }
        public string PossuiEscoamentoSanitario { get; set; }
        public string PossuiCaixaDagua { get; set; }
        public string IPTU { get; set; }
        public string FinalidadeImovel { get; set; }
        public string RegularizacaoFundiaria { get; set; }
        public decimal AreaMetroQuadrado { get; set; }
    }
}
