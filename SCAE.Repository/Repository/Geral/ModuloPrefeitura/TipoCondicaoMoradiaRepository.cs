using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral.ModuloPrefeitura
{
    public class TipoCondicaoMoradiaRepository : QueryRepository<ScaeApiContext, TipoCondicaoMoradia>, ITipoCondicaoMoradiaRepository
    {
        public TipoCondicaoMoradiaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
