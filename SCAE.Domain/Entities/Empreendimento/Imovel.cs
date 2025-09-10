using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("imovel", Schema = "empreendimento")]
    public class Imovel : IEntity
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public bool Exclusivo { get; set; }
        public bool Ocupado { get; set; }
        public bool Alugado { get; set; }
        public bool Placa { get; set; }
        public bool Financiavel { get; set; }
        public bool NaPlanta { get; set; }
        public int TipoImovelId { get; set; }
        public TipoImovel TipoImovel { get; set; }
        public int? SeguradoraId { get; set; }
        public Pessoa Seguradora { get; set; }

        public DateTime? DataVencimentoAutorizacao { get; set; }
        public decimal ValorAluguel { get; set; }
        
        public TaxaImovel Taxa { get; set; }
       [Required] public InfraestruturaImovel Infraestrutura { get; set; }

        public Imovel()
        {
            Infraestrutura = new InfraestruturaImovel();
            //Taxa = new TaxaImovel();
        }

    }

    [Owned]
    public class TaxaImovel
    {
        public string CodigoLixo { get; set; }
        public string CodigoSequencial { get; set; }
        public string CodigoAgua { get; set; }
        public string CodigoEnergia { get; set; }
        public string CodigoGas { get; set; }
        public string CodigoSpu { get; set; }
        public string CodigoHidrometro { get; set; }
        public string Descricao { get; set; }
        public decimal ApoliceSeguro { get; set; }
        public decimal ValorCaucao { get; set; }
        public decimal ValorCondominio { get; set; }
        public TaxaIptu Iptu { get; set; }
        public TaxaCmb Cmb { get; set; }

        public TaxaImovel()
        {
            Iptu = new TaxaIptu();
            Cmb = new TaxaCmb();
        }
    }
    [Owned]
    public class TaxaIptu
    {
        public string NumeroRegistro { get; set; }
        public decimal ValorVenal { get; set; }
        public decimal ValorRealImposto { get; set; }
        public decimal ValorTaxas { get; set; }
        public decimal ValorTotal { get; set; }
    }
    [Owned]
    public class TaxaCmb
    {
        public string NumeroRegistro { get; set; }
        public decimal Valor { get; set; }
        public decimal Multa { get; set; }
        public DateTime? Vencimento { get; set; }
    }


    [Owned]
    public class InfraestruturaImovel
    {
        public InfraestruturaImovelDimensao Dimensao { get; set; }
        public InfraestruturaImovelInterna Interna { get; set; }
        public InfraestruturaImovelExterna Externa { get; set; }
        public string Observacao { get; set; }

        public InfraestruturaImovel()
        {
            //Dimensao = new InfraestruturaImovelDimensao();
            //Interna = new InfraestruturaImovelInterna();
            //Externa = new InfraestruturaImovelExterna();
            Observacao = string.Empty;
        }
    }
    [Owned]
    public class InfraestruturaImovelDimensao
    {
        public decimal AreaImovel { get; set; }
        public decimal AreaTerreno { get; set; }
        public int QuantidadeQuarto { get; set; }
        public int QuantidadeBanheiro { get; set; }
        public int QuantidadeVagas { get; set; }
        public int ZonaUso { get; set; }
        public decimal CoeficienteAproveitamento { get; set; }
    }
    [Owned]
    public class InfraestruturaImovelInterna
    {
        public bool ArCondicionado { get; set; }
        public bool AreaServico { get; set; }
        public bool ArmarioQuarto { get; set; }
        public bool ArmarioCozinha { get; set; }
        public bool ArmarioBanheiro { get; set; }
        public bool Dispensa { get; set; }
        public bool Lavabo { get; set; }
        public bool VarandaGourmet { get; set; }
        public bool AreaPrivativa { get; set; }
        public bool BoxBanheiro { get; set; }
        public bool Closet { get; set; }
        public bool Mobiliado { get; set; }
        public bool SolManha { get; set; }
        public bool VistaMar { get; set; }
        public bool Dce { get; set; }
        public bool Escritorio { get; set; }
        public bool Rouparia { get; set; }
    }
    [Owned]
    public class InfraestruturaImovelExterna
    {
        public bool VagaGaragem { get; set; }
        public bool AguaIndividual { get; set; }
        public bool CercaEletrica { get; set; }
        public bool PortaoEletrico { get; set; }
        public bool BoxDespejo { get; set; }
        public bool Elevador { get; set; }
        public bool AquiecimentoEletrico { get; set; }
        public bool AquecimentoGas { get; set; }
        public bool GasCanalizado { get; set; }
        public bool Alarme { get; set; }
        public bool Cftv { get; set; }
        public bool Lavanderia { get; set; }
        public bool AquecimentoSolar { get; set; }
        public bool Jardim { get; set; }
        public bool Interfone { get; set; }
        public bool Portaria24Hrs { get; set; }
    }
}
