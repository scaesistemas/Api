using SCAE.Framework.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cp_fornecedores")]
    public class Fornecedor
    {
        [Column("idFornecedor")] public int Id { get; set; }
        [Column("RazaoSocial")] public string Nome { get; set; }
        [Column("NomeFantasia")] public string NomeFantasia { get; set; }
        [Column("CNPJ_CPF")] public string CpfCnpj { get; set; }
        public string TipoPessoa { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string Contato { get; set; }

        public string CpfCnpjFormatado => StringHelper.FormataCpfCnpj(CpfCnpj);
        public string CepFormatado => StringHelper.FormataCep(Cep);
    }
}
