using Microsoft.EntityFrameworkCore;

namespace SCAE.Domain.Entities.Geral
{
    [Owned]
    public class EmpresaDocumento
    {
        public EmpresaDocumentoItem ComprovanteResidencial { get; set; }
        public EmpresaDocumentoItem ComprovanteAtividade { get; set; }
        public EmpresaDocumentoItem Identificacao { get; set; }
        public EmpresaDocumentoItem IdentificacaoCnpj { get; set; }

        public EmpresaDocumento()
        {
            ComprovanteResidencial = new EmpresaDocumentoItem();
            ComprovanteAtividade = new EmpresaDocumentoItem();
            Identificacao = new EmpresaDocumentoItem();
            IdentificacaoCnpj = new EmpresaDocumentoItem();
        }
    }
}
