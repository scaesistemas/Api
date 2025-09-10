using System;

namespace SCAE.Domain.Models.Global
{
    public class SubcontaGlobalModel
    {
        public string CorporateName { get; set; }
        public string CpfCnpj { get; set; }
        public string CompanyType { get; set; }
        public string Address { get; set; }
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ComercialEmail { get; set; }
        public string ComercialPhone { get; set; }
        public DateTimeOffset OpeningDate { get; set; }
        public OwnerModel Owner { get; set; }
    }

    public class OwnerModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string ComplementaryAddress { get; set; }
        public string District { get; set; }
        public string NAddress { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
    }
}