using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral
{
    public class EmpresaRepository : CrudRepository<ScaeApiContext, Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ScaeApiContext context) : base(context)
        {

        }

        public void DetachedEmpresaGateway(EmpresaGateway empresa)
        {
            _context.Entry(empresa).State = EntityState.Detached;
        }

        public async Task<EmpresaGateway> GetEmpresaGatewayByIdAsync(int id)
        {
            IQueryable<EmpresaGateway> _queryEmpresaGateway = _context.Set<EmpresaGateway>();                

            return await _queryEmpresaGateway.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task RemoveEmpresaGateway(int id)
        {
            var entity = await GetEmpresaGatewayByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task<Empresa> GetByCNPJ(string cnpj)
        {
            return await _context.Empresas.SingleOrDefaultAsync(x=>x.CpfCnpj == cnpj);
        }
    }
}
