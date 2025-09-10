using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Clientes.ContratoDigitalNS
{
    [Table("modelocontratodigital", Schema = "clientes")]
    public class ModeloContratoDigital : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public TipoContratoDigital Tipo { get; set; }
        public string Conteudo { get; set; }
        public bool IsPadraoSistema { get; set; }

    }


    [Table("modelocontratodigitalempreendimento", Schema = "clientes")]
    public class ModeloContratoDigitalEmpreendimento : IEntity
    {
        public int Id { get; set; }
        public int ModeloContratoDigitalId { get; set; }
        public ModeloContratoDigital ModeloContratoDigital { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; set; }
    }

    }
