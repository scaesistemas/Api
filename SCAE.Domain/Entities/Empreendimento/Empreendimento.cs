using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("empreendimento", Schema = "empreendimento")]
    public class Empreendimento : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? EmpresaAdministradoraId { get; set; }
        public Empresa EmpresaAdministradora { get; set; }
        [StringLength(200), Required] public string Nome { get; set; }
        public int TipoId { get; set; }
        public TipoEmpreendimento Tipo { get; set; }
        public decimal PercentualAdiministradora { get; set; }
        public decimal PercentualCorretor { get; set; }
        public short AjusteIndice { get; set; }
        public string Observacao { get; set; }
        public Endereco Endereco { get; set; }
        public LegalizacaoEmpreendimento Legalizacao { get; set; }
        public EmpreendimentoInfraestrutura Infraestrutura { get; set; }
        public ICollection<LadoAdicional> LadosAdicionaisPadroes { get; set; }
        public MapaInterativo MapaInterativo { get; set; }
        public int? CodigoOrigem { get; set; }
        public string Kml { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
        public ICollection<EmpreendimentoProprietario> Proprietarios { get; set; }
        public ICollection<EmpreendimentoDocumento> Documentos { get; set; }
        public ICollection<EmpreendimentoFoto> Fotos { get; set; }
        public ICollection<EmpreendimentoDocumentoCompartilhado> DocumentosCompartilhados { get; set; }
        public ICollection<ModeloContratoDigitalEmpreendimento> ModelosDeContrato { get; set; }
        public ICollection<EmpreendimentoPessoa> EmpreendimentosPessoas { get; set; }
        public int? PlanoPagamentoModeloId { get; set; }
        public PlanoPagamentoModelo PlanoPagamento { get; set; }
        public int QuantidadeGrupo => Grupos?.Count ?? 0; 
        public int QuantidadeUnidade => Grupos?.Sum(x => x.QuantidadeUnidade) ?? 0;
        public string ImagemPrincipal { get; set; }


        public Empreendimento()
        {
            Grupos = new List<Grupo>();
            Proprietarios = new List<EmpreendimentoProprietario>();
            Documentos = new List<EmpreendimentoDocumento>();
            Fotos = new List<EmpreendimentoFoto>();
            Endereco = new Endereco();
            LadosAdicionaisPadroes = new List<LadoAdicional>();
            ModelosDeContrato = new List<ModeloContratoDigitalEmpreendimento>();
            EmpreendimentosPessoas = new List<EmpreendimentoPessoa>();
            DocumentosCompartilhados = new List<EmpreendimentoDocumentoCompartilhado>();
        }
    }

    [Owned]
    public class MapaInterativo
    {
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal ZoomStep { get; set; }

        public string ImagemMapa { get; set; }

    }

    public class EmpreendimentoInfraestrutura
    {
        public string Descricao { get; set; }
        public InfraestruturaLazer Lazer { get; set; }
        public decimal AreaUnidade { get; set; }
        public decimal AreaRua { get; set; }
        public decimal AreaPrefeitura { get; set; }
        public decimal AreaVerde { get; set; }
        public decimal AreaReservadoProprietario { get; set; }
        public decimal AreaOutras { get; set; }
        public decimal AreaUsoPublico => AreaOutras + AreaVerde;
        public decimal AreaPublicaTotal => AreaRua + AreaPrefeitura + AreaUsoPublico;
        public decimal AreaTotal => AreaUnidade + AreaRua + AreaPrefeitura + AreaVerde + AreaReservadoProprietario + AreaOutras;

        public DimensaoLote DimensaoLotePadrao { get; set; }

        public EmpreendimentoInfraestrutura()
        {
            Lazer = new InfraestruturaLazer();
        }

    }

    public class LegalizacaoEmpreendimento : Legalizacao
    {

    }
}
