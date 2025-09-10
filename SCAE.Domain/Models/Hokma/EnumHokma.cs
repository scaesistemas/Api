using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Hokma
{
    public enum EnumPaymentWayHokma
    {
        Ted = 1,
        Boleto = 2,
        Pix = 3,
        Link = 4,
        Ecommerce = 5
    }
    public enum EnumFrequencyChargeHokma
    {
        UmaVez = 1,
        PorDia = 2,
        Quinzenal = 3,
        Mensal = 4,
        Anual = 5
    }

    public enum EnumStatusHokma
    {
        Aberta = 0,
        Finalizada = 1,
        Erro = 2,
        Cancelada = 3,
        Estornada = 4,
        Bloqueada = 5
    }
}