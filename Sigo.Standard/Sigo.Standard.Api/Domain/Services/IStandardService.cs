using System.Threading.Tasks;
using Sigo.Standard.Api.Domain.Contracts;

namespace Sigo.Standard.Api.Domain.Services
{
    public interface IStandardService
    {
        Task<Standard> Create(ICreateStandardRequest request);
    }
}