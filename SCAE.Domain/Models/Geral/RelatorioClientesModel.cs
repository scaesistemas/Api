using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Geral
{
    public class RelatorioClientesModel
    {
        public CadastroOcupante CadastroOcupante { get; set; }
        public DadosConjuge DadosConjuge { get; set; }
        public InformacaoSocioEconomicaModel InformacaoSocioEconomica { get; set; }
        public InformacoesLoteModel InformacoesLote { get; set; }
        public InfomacoesMoradiaModel InformacoesMoradia { get; set; }
        public DocumentosRelatorioModel DocumentosRelatorio { get; set; }
        public InformacoesComplementaresModel InformacoesComplementares { get; set; }
        public ListaDependentes Dependente { get; set; }

        public RelatorioClientesModel()
        {
            DocumentosRelatorio = new DocumentosRelatorioModel();
        }
    }

    public class CadastroOcupante
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string EstadoCivil { get; set; }
        public string Contatos { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }
        public string NumeroRg { get; set; }
        public DateTime? EmissaoRg { get; set; }
        public string EmissorRg { get; set; }
    }

    public class DadosConjuge
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public string NumeroRg { get; set; }
        public DateTime? EmissaoRg { get; set; }
        public string EmissorRg { get; set; }
    }

    public class InformacaoSocioEconomicaModel
    {
        public List<FamiliaresListaModel> Familiares = new List<FamiliaresListaModel>();
        public Decimal TotalRendaFamilia => Familiares.Sum(x => x.Valor);
        public Decimal RendaPerCapita => Familiares.Average(x => x.Valor);
        public InformacaoSocioEconomicaModel()
        {
            Familiares = new List<FamiliaresListaModel>();
        }
    }
    public class FamiliaresListaModel
    {
        public string Nome { get; set; }
        public Decimal Valor { get; set; }
        public decimal? Porcentagem { get; set; }
    }

    public class InformacoesLoteModel
    {
        public string Quadra { get; set; }
        public string Lote { get; set; }
        public string Endereco { get; set; }
        public Decimal AreaMetroQuadrado { get; set; }
        public string Cep { get; set; }
        public string DestinoLixo { get; set; }
        public string EnergiaEletrica { get; set; }
        public string Iptu { get; set; }
        public string FormaAquisicaoUnidade { get; set; }
        public string Edificacao { get; set; }
        public bool RegularizacaoFundiaria { get; set; }
        public string AbastecimentoAgua { get; set; }
        public string EscoamentoSanitario { get; set; }
        public int Ocupacoes { get; set; }
    }

    public class DocumentosRelatorioModel
    {
        public List<DocumentosItemsModel> Documentos { get; set; }

        public DocumentosRelatorioModel() 
        { 
           Documentos = new List<DocumentosItemsModel>();
        }
    }
    public class DocumentosItemsModel
    {
        public string NomeDocumento { get; set; }
        public Byte[] Documento { get; set; }
    }
    public class InformacoesComplementaresModel
    {
        public bool BeneficioGov { get; set; }
        public int NumeroFamiliaProblema { get; set; }
        public int NumeroIdososFamilia { get; set; }
    }
    public class ListaDependentes 
    { 
      public List<ListaDependentesModel> Dependentes { get; set; }
        public ListaDependentes()
        {
            Dependentes = new List<ListaDependentesModel>();
        }
    }

    public class ListaDependentesModel
    {
        public string Nome {  get; set; }
        public DateTime DataNascimento { get; set; }
        public string Parentesco {  get; set; }
        public string Escolaridade { get; set; }
        public string Ocupacao { get; set; }
    }
}
