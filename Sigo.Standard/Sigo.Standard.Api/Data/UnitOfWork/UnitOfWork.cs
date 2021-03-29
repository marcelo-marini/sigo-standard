using System.Threading.Tasks;
using Sigo.Standard.Api.Data.Repositories;

namespace Sigo.Standard.Api.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IStandardRepository _standardRepository = null;

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IStandardRepository StandardRepository =>
            _standardRepository ?? new StandardRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}