using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sigo.Standard.Api.Data.Repositories
{
    public interface IStandardRepository : IDisposable
    {
        Task<IEnumerable<Domain.Standard>> GetStandardsAsync();
        Task<Domain.Standard> GetByExternalIdAsync(string externalId);
        Task AddAsync(Domain.Standard standard);
    }
}