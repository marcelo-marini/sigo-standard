using System.Threading.Tasks;
using Sigo.Standard.Api.Data.UnitOfWork;
using Sigo.Standard.Api.Domain.Contracts;

namespace Sigo.Standard.Api.Domain.Services
{
    public class StandardService : IStandardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StandardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Standard> Create(ICreateStandardRequest request)
        {
            var standard = Standard.Create(request);
            await _unitOfWork.StandardRepository.AddAsync(standard);

            return standard;
        }

        public async Task<Standard> Inactive(string externalId)
        {
            var standard =  await _unitOfWork.StandardRepository.GetByExternalIdAsync(externalId);

            if (standard != null)
            {
                standard.Inactive();
            }

            return standard;
        }
    }
}