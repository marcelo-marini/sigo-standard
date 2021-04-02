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

        public async Task<Standard> CreateAsync(ICreateStandardRequest request)
        {
            var standard = Standard.Create(request);
            await _unitOfWork.StandardRepository.AddAsync(standard);

            return standard;
        }

        public async Task<Standard> UpdateAsync(IUpdateStandard request)
        {
            var standard = await _unitOfWork.StandardRepository.GetByExternalIdAsync(request.Id);

            if (standard == null) return null;

            standard.Update(request);
            return standard;
        }

        public async Task DeleteAsync(string id)
        {
            var standard = await _unitOfWork.StandardRepository.GetByExternalIdAsync(id);
            
            if (standard == null) return;

            await _unitOfWork.StandardRepository.DeleteAsync(standard);
        }
    }
}