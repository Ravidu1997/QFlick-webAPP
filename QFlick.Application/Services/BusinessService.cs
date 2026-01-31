using QFlick.Application.Abstractions;
using QFlick.Domain.Interfaces;

namespace QFlick.Application.Services
{
    public class BusinessService(IUnitOfWork unitOfWork) : IBusinessService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> IsOwnBusiness(string userId, int newBusinessId)
        {
            var ownsBusiness = await _unitOfWork.BusinessRepo.IsOwnBusiness(userId, newBusinessId);
            if (!ownsBusiness)
            {
                return false;
            }
            return true;
        }

        //public async Task CreateBusiness(CreateBusinessInputDto businessData, CancellationToken cancellationToken)
        //{
        //    var mapper = new BusinessMapper();
        //    BusinessUser businessEntity = mapper.CreateBusinessDtoToBusinessUser(businessData);

        //    businessEntity.CreatedAt = DateTime.UtcNow;

        //    await _unitOfWork.BusinessRepo.AddAsync(businessEntity, cancellationToken);
        //    await _unitOfWork.SaveChangesAsync();
        //}
    }
}
