namespace SCAE.Domain.Models.Shared
{
    public class EnderecoModel
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int MunicipioId { get; set; }
        //public string Municipio { get; set; }
        public string Localidade { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }

        public string Pais { get; set; }

        public EnderecoModel()
        {
            Pais = "BRASIL";
        }
    }
}
