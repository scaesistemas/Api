using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("lead", Schema = "geral")]
    public class Lead : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string TelefonePrincipal { get; set; }
        public string TelefoneSecundario { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public int? GrauInteresseId { get; set; }
        public GrauInteresse GrauInteresse { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int OrigemId { get; set; }
        public OrigemLead Origem { get; set; }
        public int? CorretorResponsavelId { get; set; }
        public Usuario CorretorResponsavel { get; set; }
        public int? ComoLeadNosEncontrouId { get; set; }
        public ComoLeadNosEncontrou ComoLeadNosEncontrou { get; set; }
        public int? ComoLeadContactouId { get; set; }
        public ComoLeadContactou ComoLeadContactou { get; set; }
        public DateTime? DataVinculoCorretor { get; set; }
        public DateTime? DataInsercaoFunil { get; set; }
        public DateTime? DataUltimaInteracao { get; set; }


        public int PosicaoFunil { get; set; }
        public int? ColunaFunilId { get; set; }
        public ColunaFunil ColunaFunil { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<HistoricoLead> Historicos { get; set; }
        public ICollection<Atendimento> Atendimentos { get; set; }
        public ICollection<LeadDocumento> Documentos { get; set; }

        public int DiasDesdeUltimaInteracao => DataUltimaInteracao.HasValue ? DateTime.Now.Subtract(DataUltimaInteracao.Value).Days : 0;
        public int DiasDesdeUltimaInsercaoFunil => DataInsercaoFunil.HasValue ? DateTime.Now.Subtract(DataInsercaoFunil.Value).Days : 0;

        public string EmpreendimentoNome => Reservas.Select(x => x.Unidade).Select(x => x.Grupo).FirstOrDefault()?.Empreendimento.Nome ?? "";
        public string UnidadeNome => Reservas.Select(x => x.Unidade).FirstOrDefault()?.Nome ?? "";
        public string QuadraNome => Reservas.Select(x => x.Unidade).Select(x => x.Grupo).FirstOrDefault()?.Nome ?? "";


        public int? SexoId { get; set; }
        public Sexo Sexo { get; set; }
        [StringLength(15)] public string Rg { get; set; }
        [StringLength(10)] public string OrgaoExpedido { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public DateTime? DataNascimento { get; set; }
        [StringLength(09)] public string Cep { get; set; }
        [StringLength(80)] public string Logradouro { get; set; }
        [StringLength(60)] public string Numero { get; set; }
        [StringLength(60)] public string Complemento { get; set; }
        [StringLength(100)] public string Bairro { get; set; }
        public int? MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public int? EstadoId { get; set; }
        public Estado Estado { get; set; }
        public Qualificacao Qualificacao { get; set; }


        public Lead()
        {
            Reservas = new List<Reserva>();
            Historicos = new List<HistoricoLead>();
            Atendimentos = new List<Atendimento>();
            Documentos = new List<LeadDocumento>();
            Qualificacao = new Qualificacao();
        }
    }

}
