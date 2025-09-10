using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.Gateway
{
    public class BoletoSafraModel
    {
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public string Danfe { get; set; }
        public BoletoSafraDocumentoModel Documento { get; set; }
        

        public BoletoSafraModel()
        {
            Documento = new BoletoSafraDocumentoModel();
        }
    }

    public class BoletoSafraDocumentoModel
    {
        public string Numero { get; set; }
        public string NumeroCliente { get; set; }
        public int DiasDevolucao { get; set; }
        public string Especie { get; set; }
        public string DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public int CodigoMoeda { get; set; }
        public int QuantidadeDiasProtesto { get; set; }
        public char IdentificacaoAceite { get; set; }
        public string CampoLivre { get; set; }
        public decimal ValorAbatimento { get; set; }

        public BoletoSafraDescontoModel Desconto { get; set; }
        public BoletoSafraMultaModel Multa { get; set; }
        public BoletoSafraPagadorModel Pagador { get; set; }
        public List<BoletoSafraMensagemModel> Mensagens { get; set; }

        public BoletoSafraDocumentoModel()
        {
            DiasDevolucao = 0;
            Especie = "01";
            CodigoMoeda = 9;
            QuantidadeDiasProtesto = 0;
            IdentificacaoAceite = 'N';
            Multa = new BoletoSafraMultaModel();
            Pagador = new BoletoSafraPagadorModel();
            Mensagens = new List<BoletoSafraMensagemModel>();
           // Desconto = new BoletoSafraDescontoModel();
        }
    }

    public class BoletoSafraDescontoModel
    {
        public string Data { get; set; }
        public decimal Valor { get; set; }
        public string Data2 { get; set; }
        public decimal? Valor2 { get; set; }
        public string Data3 { get; set; }
        public decimal? Valor3 { get; set; }
        public char TipoDesconto { get; set; }

        public BoletoSafraDescontoModel()
        {
            TipoDesconto = '1';
        }
    }

    public class BoletoSafraMultaModel
    {
        public string dataMulta { get; set; }
        public string dataJuros { get; set; }
        public decimal TaxaJuros { get; set; }
        public decimal TaxaMulta { get; set; }
    }

    public class BoletoSafraPagadorModel
    {
        public string Nome { get; set; }
        public char TipoPessoa { get; set; }
        public string NumeroDocumento { get; set; }
        public BoletoSafraEnderecoModel Endereco { get; set; }

        public BoletoSafraPagadorModel()
        {
            Endereco = new BoletoSafraEnderecoModel();
        }
    }

    public class BoletoSafraEnderecoModel
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set;}
        public string Cep { get; set; }
    }

    public class BoletoSafraMensagemModel
    {
        public string Posicao { get; set; }
        public string Descricao { get; set; }

        public BoletoSafraMensagemModel(string posicao, string descricao)
        {
            Posicao = posicao;
            Descricao = descricao;
        }
    }
}
