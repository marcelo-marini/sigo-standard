using System.Threading.Tasks;
using Sigo.Standard.Api.Data.UnitOfWork;
using Sigo.Standard.Api.Domain.Contracts;
using Sigo.Standard.Api.Domain.Services;
using Sigo.Standard.Api.Models.Response;

namespace Sigo.Standard.Api.Application
{
    public class StandardAppService : IStandardAppService
    {
        private readonly IStandardService _service;
        private readonly IUnitOfWork _unitOfWork;

        public StandardAppService(IStandardService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStandardResponse> Create(ICreateStandardRequest request)
        {
            var standard = await _service.Create(request);
            await _unitOfWork.CommitAsync();

            return GetStandardResponse.Create(standard);
        }
    }
}