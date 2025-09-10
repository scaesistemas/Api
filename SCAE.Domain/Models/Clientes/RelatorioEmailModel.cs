using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Clientes
{
    public class RelatorioEmailModel
    {
        public List<EmailModel> Emails { get; set; }
        public int TotalEmails { get; set; }

        public RelatorioEmailModel()
        {
            Emails = new List<EmailModel>();
        }
    }

    public class EmailModel
    {
        public int Id { get; set; }
        public string EmpresaNome { get; set; }
        public string Email { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}
