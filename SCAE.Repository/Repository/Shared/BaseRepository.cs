using Microsoft.EntityFrameworkCore;

namespace SCAE.Data.Repository.Shared
{
    public class BaseRepository<TContext> where TContext : DbContext
    {
        protected TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }
    }
}
