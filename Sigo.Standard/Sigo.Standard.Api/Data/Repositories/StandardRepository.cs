using System;
using System.Collections.Generic;
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
            var query = _context.Set<Domain.Standard>().AsNoTracking();

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

        public Task DeleteAsync(Domain.Standard standard)
        {
            _context.Remove(standard);
            return Task.CompletedTask;
        }
    }
}