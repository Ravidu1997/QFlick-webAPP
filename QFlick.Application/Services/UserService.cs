using QFlick.Application.Abstractions;
using QFlick.Application.Interfaces;
using QFlick.Application.Mappers;
using QFlick.Domain.DTOs;
using QFlick.Domain.DTOs.Client;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Entities.Client.User;
using QFlick.Domain.Interfaces;

namespace QFlick.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService1;
        private readonly IAuthenticationService _authService2;

        public UserService(IUnitOfWork unitOfWork, IAuthService authService1, IAuthenticationService authService2)
        {
            _unitOfWork = unitOfWork;
            _authService1 = authService1;
            _authService2 = authService2;
        }

        public async Task AddNewCustomer(RegCustomerDto user, CancellationToken cancellationToken)
        {
            var identityId = await _authService2.RegisterAsync(user.Email, user.Password);

            var mapper = new UserMapper();
            AppUser userEntity = mapper.RegCustomerDtoToAppUser(user);

            userEntity.UId = identityId;
            userEntity.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.UserRepo.AddAsync(userEntity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddNewBusiness(RegBusinessDto user, CancellationToken cancellationToken)
        {
            var identityId = await _authService2.RegisterAsync(user.Email, user.Password);

            var mapper = new UserMapper();
            BusinessUsers businessEntity = mapper.RegBusinessDtoToStaffUser(user);

            businessEntity.UId = identityId;
            businessEntity.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.BusinessUserRepo.AddAsync(businessEntity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AppUserDto> GetUserDetailAsync(string uid)
        {
            var mapper = new UserMapper();

            AppUser loggedUser = await _unitOfWork.UserRepo.GetUserDetail(uid);
            AppUserDto user = mapper.UserToAppUserDto(loggedUser);
            return user;
        }
    }
}
