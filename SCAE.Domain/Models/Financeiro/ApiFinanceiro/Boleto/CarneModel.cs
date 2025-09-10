using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;

public class CarneModel
{
        public List<BoletoModel> Boletos{ get; set; }

    public CarneModel()
    {
        Boletos = new List<BoletoModel>();
    }
}
