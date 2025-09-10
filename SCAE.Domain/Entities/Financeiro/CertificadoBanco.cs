using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Financeiro
{
    public class CertificadoBanco
    {
        public int Id { get; set; }
        public int ContaCorrenteId { get; set; }
        public ContaCorrente corrente { get; set; }
        public string Nome { get; set; }
        public string Formato { get; set; }
        public DateTime DataValidacaoInicial { get; set; }
        public DateTime DataValidacaoFinal { get; set; }
        [NotMapped]public bool Excluido { get; set; }
        public string Senha { get; set; }
        public byte[] Conteudo { get; set; }
    }
}
