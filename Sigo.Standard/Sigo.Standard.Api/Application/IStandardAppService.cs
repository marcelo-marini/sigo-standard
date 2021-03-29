using System.Threading.Tasks;
using Sigo.Standard.Api.Domain.Contracts;
using Sigo.Standard.Api.Models.Response;

namespace Sigo.Standard.Api.Application
{
    public interface IStandardAppService
    {
        Task<GetStandardResponse> Create(ICreateStandardRequest request);
    }
}