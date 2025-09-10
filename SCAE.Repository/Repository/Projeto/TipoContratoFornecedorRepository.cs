using SCAE.Data.Context;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Projeto
{
    public class TipoContratoFornecedorRepository : QueryRepository<ScaeApiContext, TipoContratoFornecedor>, ITipoContratoFornecedorRepository
    {
        public TipoContratoFornecedorRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
