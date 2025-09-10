using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Base;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Base
{
    public class AssinanteRepository : CrudRepository<ScaeBaseContext, Assinante>, IAssinanteRepository
    {
        public AssinanteRepository(ScaeBaseContext context) : base(context)
        {
        }

        public Assinante ObterAssinante(string host)
        {
            var domain = (from
                        assinante in GetAll().Include(x => x.Dominios).AsNoTracking()
                          from
                              dominio in assinante.Dominios
                          where
                              dominio.Nome.ToLower() == host.ToLower()
                          select
                              assinante).SingleOrDefault();

            if (domain == null)
                domain = GetAll().Include(x => x.Dominios).AsNoTracking().SingleOrDefault(x => x.SubDominio == "homologacao");

            return domain;
        }
        public void DetachedDominio(AssinanteDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Detached;
        }

        public async Task RemoveDominio(int id)
        {
            var entity = await GetDominioByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }
       
       public async Task<AssinanteDominio> GetDominioByIdAsync(int id)
       {
           IQueryable<AssinanteDominio> _queryDominio = _context.Set<AssinanteDominio>();

           return await _queryDominio.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
       }

    }
}
