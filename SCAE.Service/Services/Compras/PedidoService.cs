using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NFe.Classes;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Interface.Geral;
using SCAE.Domain;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Compras;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Compras;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Interfaces.Compras;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static SCAE.Domain.Entities.Almoxarifado.Produto;

namespace SCAE.Service.Services.Compras
{
    public class PedidoService : CrudService<Pedido, IPedidoRepository>, IPedidoService
    {
        public PedidoService(IPedidoRepository repository) : base(repository)
        {

        }

       
    }
}
