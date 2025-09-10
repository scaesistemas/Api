using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;

namespace SCAE.Api.Models.Financeiro
{
    public class AgrupaParcelaModel
    {
        public DateTime DataVencimento { get; set; }
        public List<int> ParcelaIds { get; set; }
        public bool AplicarEncargos { get; set; }

        public AgrupaParcelaModel()
        {
            ParcelaIds = new List<int>(); 
        }
    }
}
