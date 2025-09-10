using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("orcamentoobras", Schema = "orcamentoobras")]
    public class OrcamentoObras : IEntity
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; private set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; private set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Referencia { get; set; } //Data
        public int EstadoId { get; set; }
        public Estado Estado { get; private set; }
        public int OrigemId { get; set; }
        public OrigemDados Origem { get; private set; }
        public bool EncargosDesonerados { get; set; }
        public decimal PercentualBDI { get; set; }

        public ICollection<OrcamentoEtapa> Etapas { get; set; }
        public decimal ValorTotalSemBDI => Soma(EncargosDesonerados);
        public decimal ValorBDI => ValorTotalSemBDI * PercentualBDI / 100;
        public decimal ValorTotalComBDI => ValorTotalSemBDI + ValorBDI;

        public OrcamentoObras()
        {
            DataHora = DateTime.Now;
            DataHoraAtualizacao = DateTime.Now;
            EncargosDesonerados = false;
            Etapas = new List<OrcamentoEtapa>();
        }

        private decimal Soma(bool desonerado)
        {
            if (Estado == null)
                return 0;

            decimal valorTotal = 0;
            foreach (var etapa in Etapas)
                valorTotal += etapa.Soma(desonerado) * etapa.Quantidade;

            return valorTotal;
        }

    }

}