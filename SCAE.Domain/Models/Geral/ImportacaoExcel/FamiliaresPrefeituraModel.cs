using SCAE.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class FamiliaresPrefeituraModel
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo CPF/CNPJ ultrapassou o limite de caracteres")]
        public string CpfCnpj { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo RG ultrapassou o limite de caracteres")]
        public string RG { get; set; }
        [StringLength(15, ErrorMessage = "O valor do campo Orgao Expedidor ultrapassou o limite de caracteres")]
        public string OrgaoExpedidor { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public decimal RendaBruta { get; set; }
        public string GrauParentesco { get; set; }
        public string Escolaridade { get; set; }
        public string Profissao { get; set; }
        public string Dependente { get; set; }
    }
}
