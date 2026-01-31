using QFlick.Domain.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> Login(LoginInputDto UserData, CancellationToken cancellationToken);
        Task SetUserRoleClaimAsync(string uid, string role, int? businessId);
        Task<string> GetCurrentUId();
    }
}
