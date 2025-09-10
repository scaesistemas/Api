using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioClassificacaoModel
    {
        public ICollection<DespesaClassificacaoModel> DespesaClassificacoes { get; set; }
    }
     
    public class DespesaClassificacaoModel
    {
        public ICollection<ClassificacoesModel> Classificacoes { get; set; }
    }

    public class ClassificacoesModel
    {
        public ICollection<ParcelasClassificacaoModel> ParcelasClassificacao { get; set; }

    }

    public class ParcelasClassificacaoModel
    {
        public string EmpresaNome { get; set; }
        public string EmpreendimentoNome { get; set; }

        public decimal Valor { get; set; }
        public string CentroCusto { get; set; }
        public string ContaGerencial { get; set; }
        public decimal Porcentagem { get; set; }
    }
}
