using Microsoft.AspNetCore.Http;
using SCAE.Api.Models.Financeiro;
using SCAE.Data.Context;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models;
using SCAE.Domain.Models.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using SCAE.Domain.Models.GalaxPay;
using SCAE.Domain.Models.Geral;
using SCAE.Domain.Models.Geral.ImportacaoExcel;
using SCAE.Service.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro
{
    public interface IReceitaService : ICrudService<Receita>
    {
        IQueryable<ReceitaParcela> GetParcelaAll(string include = "");
        IQueryable<ReceitaTransacao> GetTransacaoAll(string include = "");
    }
}
