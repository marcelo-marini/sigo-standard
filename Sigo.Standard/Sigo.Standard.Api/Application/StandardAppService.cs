using System.Collections.Generic;
using System.Linq;
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

        public async Task<GetStandardResponse> CreateAsync(ICreateStandardRequest request)
        {
            var standard = await _service.CreateAsync(request);
            await _unitOfWork.CommitAsync();

            return GetStandardResponse.Create(standard);
        }

        public async Task<IEnumerable<GetStandardResponse>> GetAllAsync()
        {
            var list = new List<GetStandardResponse>();
            var standards = await _unitOfWork.StandardRepository.GetStandardsAsync();

            if (standards != null)
            {
                list.AddRange(standards.Select(GetStandardResponse.Create
                ));
            }

            return list;
        }

        public async Task<GetStandardResponse> GetbyExternalIdAsync(string externalId)
        {
            var response = await _unitOfWork.StandardRepository.GetByExternalIdAsync(externalId);
            return GetStandardResponse.Create(response);
        }

        public async Task<GetStandardResponse> UpdateAsync(IUpdateStandard request)
        {
            var standard = await _service.UpdateAsync(request);

            if (standard == null) return null;

            await _unitOfWork.CommitAsync();

            return GetStandardResponse.Create(standard);
        }

        public async Task DeleteAsync(string id)
        {
            await _service.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}