using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral.ModuloPrefeitura
{
    public class TipoEnergiaMoradiaService : QueryService<TipoEnergiaMoradia, ITipoEnergiaMoradiaRepository>, ITipoEnergiaMoradiaService
    {
        public TipoEnergiaMoradiaService(ITipoEnergiaMoradiaRepository repository) : base(repository)
        {

        }
    }
}
