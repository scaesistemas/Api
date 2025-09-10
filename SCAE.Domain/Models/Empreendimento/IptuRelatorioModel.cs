namespace SCAE.Domain.Models.Empreendimento
{
    public class IptuRelatorioModel
    {
        public string ClienteNomeCPF { get; set; }

        public string ClienteLogradouro { get; set; }
        public string ClienteCidade { get; set; }
        public string ClienteUf { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteCep { get; set; }


        public string EmpresaNome {get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; } 
        public string UnidadeNome { get; set; }

        public string UnidadeMatricula { get; set; }
        public decimal UnidadeAreaTotal { get; set; }

    }
}
