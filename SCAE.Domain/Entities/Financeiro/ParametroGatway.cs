using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Exceptions;
using System;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("parametrogatway", Schema = "financeiro")]
    public class ParametroGatway : IEntity
    {
        public int Id { get; set; }
        public bool Principal { get; set; }
        public int ParametroId { get; set; }
        public Parametro Parametro { get; set; }
        public int TipoId { get; set; }
        public TipoGateway Tipo { get; set; }
        public Encargo EncargoFinanceiro { get; set; }
        public decimal TaxaBoleto { get; set; }
        [StringLength(60)] public string Instrucao1 { get; set; }
        [StringLength(60)] public string Instrucao2 { get; set; }
        [StringLength(60)] public string Instrucao3 { get; set; }
        public GatewaySafra Safra { get; set; }
        public GatewayGalaxPay GalaxPay { get; set; }
        public GatewayAsaas Asaas { get; set; }
        public GatewayContapay ContaPay { get; set; }
        public GatewayGlobal GlobalPay { get; set; }
        public List<ContaCorrenteSplit> ContasCorrentesSplit { get; set; }
        public bool isGerado { get; set; }

        public ParametroGatway()
        {
            EncargoFinanceiro = new Encargo();
            Safra = new GatewaySafra();
            Asaas = new GatewayAsaas();
            ContaPay = new GatewayContapay();
            GlobalPay = new GatewayGlobal();
            GalaxPay = new GatewayGalaxPay();
        }
    }

    [Owned]
    public class GatewaySafra
    {
        [MaxLength(25)] public string ClientId { get; set; }
        [MaxLength(25)] public string Usuario { get; set; }
        [MaxLength(25)] public string Senha { get; set; }
        public string Agencia { get; set; }
        public string AgenciaSemDigito => !string.IsNullOrEmpty(Agencia) ?
                                                (Agencia.Length > 4 ? Agencia.Substring(0, 4) : throw new Exception("É necessário que o campo Agência possua pelo menos 5 caracteres"))
                                                : "";
        public string Conta { get; set; }
        public string ContaSemDigito => Conta != null && Conta.Contains("-") ? Conta.Substring(0, Conta.IndexOf('-')) : "";
        public string DigitoConta => Conta != null && Conta.Contains("-") ? Conta.Substring(Conta.IndexOf('-') + 1) : "";
        public string NossoNumeroInicial { get; set; }
    }

    [Owned]
    public class GatewayGalaxPay
    {
        [MaxLength(25)] public string Id { get; set; }
        [MaxLength(60)] public string Hash { get; set; }
        public bool isSubcontaAtiva { get; set; }
        public bool isSubconta { get; set; }
        public bool? DocumentosEnviados { get; set; }
    }

    [Owned]
    public class GatewayAsaas
    {
        public string AccessToken { get; set; } = "";
    }
    [Owned]
    public class GatewayContapay
    {
        public string email { get; set; } = "";
        public string AccessToken { get; set; } = "";
    }

    [Owned]
    public class GatewayGlobal
    {
        public string email { get; set; } = "";
        public string Senha { get; set; } = "";
        public bool isSubcontaAtiva { get; set; }
        public bool isSubconta { get; set; }
        public bool DocumentosEnviados { get; set; }
    }
}
