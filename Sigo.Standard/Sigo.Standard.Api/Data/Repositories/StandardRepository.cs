using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sigo.Standard.Api.Data.Repositories
{
    public class StandardRepository : IStandardRepository
    {
        private readonly ApplicationDbContext _context;

        public StandardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Domain.Standard>> GetStandardsAsync()
        {
            IQueryable<Domain.Standard> query = _context.Set<Domain.Standard>();

            return await query.ToListAsync();
        }

        public async Task<Domain.Standard> GetByExternalIdAsync(string externalId)
        {
            return await _context.Standards.FirstOrDefaultAsync(x => x.ExternalId == externalId);
        }

        public async Task AddAsync(Domain.Standard standard)
        {
            await _context.Standards.AddAsync(standard);
        }
    }
}