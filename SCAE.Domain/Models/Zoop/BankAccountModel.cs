using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Zoop
{
    public class BankAccountModel
    {
        public string Id { get; set; }
        [JsonProperty("holder_name")] public string RazaoSocial { get; set; }
        [JsonProperty("ein")] public string Cnpj { get; set; }
        [JsonProperty("taxpayer_id")] public string Cpf { get; set; }
        [JsonProperty("bank_code")] public string Codigo { get; set; }
        [JsonProperty("routing_number")] public int Agencia { get; set; }
        [JsonProperty("account_number")] public int Conta { get; set; }
        [JsonProperty("type")] public string Tipo { get; set; } //checking ou savings

        public BankAccountModel()
        {

        }

        public BankAccountModel(string id) : this()
        {
            Id = id;
        }
    }

    public class ReturnBankAccountModel
    {
        public string Id { get; set; }
        public string Resource { get; set; }
        public string Type { get; set; }
        public bool Usued { get; set; }
        [JsonProperty("bank_account")] public BankAccountModel BankAccount { get; set; }

        public ReturnBankAccountModel()
        {
            BankAccount = new BankAccountModel();
        }

        public ReturnBankAccountModel(string id, string bankAccountId) : this()
        {
            Id = id;
            BankAccount.Id = bankAccountId;
        }
    }
}
