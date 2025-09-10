using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Hokma
{
    public class UserBankHokmaModel
    {
        public string Agency { get; set; }
        public string Number { get; set; }
        public string BankCode { get; set; }
        public string PixKey { get; set; }
    }
}