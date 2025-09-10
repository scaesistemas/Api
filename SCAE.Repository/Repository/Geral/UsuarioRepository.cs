using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral
{
    public class UsuarioRepository : CrudRepository<ScaeApiContext, Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ScaeApiContext context) : base(context)
        {

        }

        public override void Update(Usuario entity)
        {
            _context.Entry(entity).Property(x => x.Login).IsModified = false;

            base.Update(entity);
        }

        public async Task<Usuario> Login(string login)
        {
            var usuario = await _context.Usuarios
                    .SingleOrDefaultAsync(x => x.Login.ToUpper() == login.ToUpper() && x.Ativo);

            return usuario;
        }

        public async Task<bool> LoginDuplicado(string login)
        {
            return await _context.Usuarios.AnyAsync(x=> x.Login.ToUpper() == login.ToUpper());
        }
    }
}
