namespace SCAE.Api.Models.Geral
{
    public class AlteraSenhaModel
    {
        public int UsuarioId { get; set; }
        public string SenhaAntiga { get; set; }
        public string SenhaNova { get; set; }
    }
}
