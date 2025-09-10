using SCAE.Domain.Entities.Geral.CRMVendas;
using System.Collections.Generic;
using System.Linq;


namespace SCAE.Domain.Models.Geral.CRMVendas
{
    public class AtendimentoTarefaModel
    {
        public List<Atendimento> Atendimentos { get; set; }
        public List<Atendimento> Tarefas { get; set; }
        public int TarefasEmAberto => Tarefas?.Count(x => x.Realizado == false) ?? 0;

        public AtendimentoTarefaModel()
        {
            Atendimentos = new List<Atendimento>();
            Tarefas = new List<Atendimento>();
        }
    }
}
