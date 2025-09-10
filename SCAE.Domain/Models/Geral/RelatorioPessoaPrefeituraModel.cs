using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Geral
{
    public class RelatorioPessoaPrefeituraModel
    {
        public CadastroOcupantePrefeitura CadastroOcupante { get; set; }
        public DadosConjuge DadosConjuge { get; set; }
        public InformacaoSocioEconomicaModel InformacaoSocioEconomica { get; set; }
        public InfomacoesMoradiaModel InformacoesMoradia { get; set; }
        public DocumentosRelatorioModel DocumentosRelatorio { get; set; }
        public InformacoesComplementaresModel InformacoesComplementares { get; set; }
        public ListaDependentes Dependente { get; set; }

        public RelatorioPessoaPrefeituraModel()
        {
            DocumentosRelatorio = new DocumentosRelatorioModel();
        }
    }

    public class CadastroOcupantePrefeitura
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string EstadoCivil { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }
        public string NumeroRg { get; set; }
        public DateTime? EmissaoRg { get; set; }
        public string EmissorRg { get; set; }
    }
     
    public class InfomacoesMoradiaModel
    {
        public string Endereco { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string AbastecimentoAgua { get; set; }
        public string EscoamentoSanitario { get; set; }
        public int NumeroOcupacoes { get; set; }
        public string IPTU { get; set; }
        public string FinalidadeImovel { get; set; }
        public string PossuiImovel { get; set; }
        public int QuantImoveis { get; set; }
        public Decimal AreaMetroQuadrado { get; set; }
        public string DominioImovel { get; set; }
        public string EnergiaEletrica { get; set; }
        public string DestinoLixo { get; set; }
        public string Edificacao { get; set; }
        public string FormaAquisicao { get; set; }
        public string BeneficiarioRegularizacaoFundiaria { get; set; }
        public int Ocupacoes { get; set; }
    }
}
