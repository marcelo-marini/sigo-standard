using System.Collections.Generic;
using System.Threading.Tasks;
using Sigo.Standard.Api.Domain.Contracts;
using Sigo.Standard.Api.Models.Response;

namespace Sigo.Standard.Api.Application
{
    public interface IStandardAppService
    {
        Task<GetStandardResponse> CreateAsync(ICreateStandardRequest request);
        Task<IEnumerable<GetStandardResponse>> GetAllAsync();
        Task<GetStandardResponse> GetbyExternalIdAsync(string externalId);
        Task<GetStandardResponse> UpdateAsync(IUpdateStandard request);
        Task DeleteAsync(string id);
    }
}