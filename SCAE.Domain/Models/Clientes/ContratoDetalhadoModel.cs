
using SCAE.Domain.Entities.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes
{
    public class ContratoDetalhadoModel
    {
        //Informações dos envolvidos
        public int Id { get; set; }
        public string NumeroSequencia { get; set; }
        public string SituacaoNome { get; set; }
        public decimal Valor { get; set; }

        public decimal ValorComJuros { get; set; }

        public decimal ValorRecebido { get; set; }

        public string EmpresaNome { get; set; }


    
        //Informações do Produto
        public string TipoProdutoNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; }

        public int? UnidadePrincipalId { get; set; }
        public string LoteNome { get; set; }

        public int TipoAmortizacaoId { get; set; }

        public int IntervaloReajusteId { get; set; }

        public decimal JurosAmortizacao { get; set; }

        public int MesReajuste {  get; set; }    


        // Data e reajustes

        public DateTime DataContrato { get; set; }
        public string IndiceNome { get; set; }

        public string IntervaloNome { get; set;}

        public int AnoPrimeiroReajuste { get; set;}

        public string TipoTabelaNome { get; set;}


        public List<ReceitaModel> Receitas { get; set; } = new List<ReceitaModel>();

        public List<ClienteModel> Clientes { get; set; } = new List<ClienteModel>();

        public List<CorretorModel> Corretores { get; set; } = new List<CorretorModel>();

        public ICollection<HistoricoModel> HistoricoSituacoes { get; set; } = new List<HistoricoModel>();

 
        public List<UnidadeAdicionalModel> UnidadesAdicionais { get; set; } = new List<UnidadeAdicionalModel>();


    }

    public class ReceitaModel
    {
        public string TipoNome { get; set;}
        public decimal ReceitaTotal { get; set; }
        public decimal TotalReceitaComJuros { get; set; }

        public decimal TotalRecebido { get; set; }

        public int QtdeParcela { get; set; }

        public int QtdeParcelaRestante { get; set; }

        public int  QtdeParcelaPagas { get; set; }
    }


    public class HistoricoModel
    {
        public DateTime DataAlteracao { get; set; }

        public string SituacaoNome { get; set; }

        public string UsuarioNome { get; set; }

        public int SituacaoId {  get; set; }    

    }

    public class UnidadeAdicionalModel
    {
        public  int Id { get; set; }    

        public string Nome { get; set; }     
    }


    public class CorretorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public decimal Percentual { get; set; }
        public decimal ValorFixo { get; set; }


        public bool IsPercentual { get; set; }

    }


    public class ClienteModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string CpfCnpj { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
