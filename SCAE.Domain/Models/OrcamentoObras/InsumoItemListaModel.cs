using SCAE.Domain.Entities.OrcamentoObras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.OrcamentoObras
{
    //Resposta para o endpoint que lista os insumos e seus dados
    public class InsumoItemListaModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoId { get; set; }
        public string TipoNome {  get; set; }
        public int UnidadeId { get; set; }
        public string UnidadeNome { get; set; }
        public int OrigemId { get; set; }
        public string OrigemNome { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNome { get; set; }
        public string Observacao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public decimal ValorDesonerado { get; set; }
        public decimal ValorNaoDesonerado { get; set; }
    }
}
