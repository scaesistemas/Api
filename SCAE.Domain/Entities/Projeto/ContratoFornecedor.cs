using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("ContratoFornecedor", Schema = "projeto")]
    public class ContratoFornecedor : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int Numero { get; set; }
        public int FornecedorId { get; set; }
        public Pessoa Fornecedor { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; set; }
        public DateTime PrazoInicio { get; set; }
        public DateTime PrazoFim { get; set; }
        public DateTime PrazoGarantiaInicio { get; set; }
        public DateTime PrazoGarantiaFim { get; set; }
        public int TipoId { get; set; }
        public TipoContratoFornecedor Tipo { get; private set; }
        public ICollection<ContratoFornecedorItem> Itens { get; set; }
        public ICollection<ContratoFornecedorDocumento> Documentos { get; set; }
        public ICollection<ContratoFornecedorObservacao> Observacoes { get; set; }
        public int CentroCustoId { get; set; }
        public int ContaGerencialId { get; set; }

        public ContratoFornecedor()
        {
            Itens = new List<ContratoFornecedorItem>();
            Documentos = new List<ContratoFornecedorDocumento>();
            Observacoes = new List<ContratoFornecedorObservacao>();
        }

    }
}