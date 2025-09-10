using SCAE.Data.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAE.Domain.Entities.Projeto;


namespace SCAE.Data.Interface.Projeto
{
    public interface IContratoFornecedorRepository : ICrudRepository<ContratoFornecedor>
    {
        int ProximoNumero();
    }

}
