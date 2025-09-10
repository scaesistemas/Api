using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class SubContaCPFModel
    {
        [JsonProperty("name")]
        public string Nome { get; set; }

        /// <summary>
        /// CPF do cliente. Apenas números.
        /// </summary>
        [JsonProperty("document")]
        public string CPF { get; set; }

        [JsonProperty("phone")]
        [MaxLength(11)]
        public string Telefone { get; set; }

        [JsonProperty("emailContact")]
        public string Email { get; set; }

        [JsonProperty("logo")]
        public byte[] Logo { get; set; }

        [JsonProperty("canAccessPlatform")]
        public bool PodeAcessarPlataforma { get; set; }

        [JsonProperty("softDescriptor")]
        public string NomeFatura { get; set; }

        //[JsonProperty("Professional")]
        //public ProfissaoSubContaModel Profissao { get; set; }

        // [JsonProperty("Address")]
        // public EnderecoSubContaModel Endereco { get; set; }

        // public DocumentosPedidos DocumentosPedidosPessoaFisica { get; set; }


        // public void ValidarDocumentos()
        // {
        //     if (DocumentosPedidosPessoaFisica == null)
        //     {
        //         throw new ArgumentException("Os documentos da subconta não foram preenchidos.");
        //     }

        //     if (DocumentosPedidosPessoaFisica.ContratoSocial == null || DocumentosPedidosPessoaFisica.ContratoSocial.Length == 0)
        //         throw new ArgumentException("O contrato social é obrigatório.");
        // }

    }


}
public class DocumentosPedidosPessoaFisica
{
    public byte[] ContratoSocial { get; set; }
}