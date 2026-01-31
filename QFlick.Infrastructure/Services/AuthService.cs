using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using QFlick.Application.Interfaces;
using QFlick.Domain.DTOs.Auth;
using QFlick.Domain.Entities.Client.Business;
using QFlick.Domain.Entities.Client.User;
using QFlick.Domain.Interfaces;
using System.Security;

namespace QFlick.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDto?> Login(LoginInputDto userData, CancellationToken cancellationToken)
        {
            var decodedToken = await FirebaseAuthentication();
            if (decodedToken == null)
            {
                return null;
            }
            if (userData.IsBusinessLogin is true)
            {
                BusinessUser? user = (await _unitOfWork.BusinessUserRepo.FindAsync(u => u.UId == decodedToken.Uid, cancellationToken)).FirstOrDefault();
                if (user == null)
                {
                    if (userData.IsSignFromGoogle is false)
                        return null;

                    if (userData.IsSignFromGoogle is true)
                    {
                        BusinessUser newUser = new()
                        {
                            BusinessName = "",
                            CategoryId = 0,
                            City = "",
                            UId = decodedToken.Uid,
                            BusinessEmail = decodedToken.Claims["email"].ToString()!,
                            IsAdmin = true,
                            CreatedAt = DateTime.UtcNow,
                        };

                        await _unitOfWork.BusinessUserRepo.AddAsync(newUser, cancellationToken);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
                //await SetUserRoleClaimAsync(decodedToken.Uid, "business-admin", 2);
                return new LoginResponseDto
                { 
                    Message = "Login successfully!",
                    UserRole = "business-admin"
                };
            }
            else
            {
                AppUser? user = (await _unitOfWork.UserRepo.FindAsync(u => u.UId == decodedToken.Uid, cancellationToken)).FirstOrDefault();
                if (user == null)
                {
                    if (userData.IsSignFromGoogle is false)
                        return null;

                    if (userData.IsSignFromGoogle is true)
                    {
                        AppUser newUser = new()
                        {
                            UId = decodedToken.Uid,
                            Email = decodedToken.Claims["email"].ToString(),
                            CreatedAt = DateTime.UtcNow,
                        };

                        await _unitOfWork.UserRepo.AddAsync(newUser, cancellationToken);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
                //await SetUserRoleClaimAsync(decodedToken.Uid, "user", null);
                return new LoginResponseDto
                {
                    Message = "Login successfully!",
                    UserRole = "User"
                };
            }
        }

        public async Task<string> GetCurrentUId()
        {
            var decodedToken = await FirebaseAuthentication();
            if (decodedToken == null)
            {
                throw new SecurityException("Token is invalid.");
            }
            return decodedToken.Uid;
        }

        private async Task<FirebaseToken?> FirebaseAuthentication()
        {
            var authHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader))
            {
                return null;
            }
            var idToken = authHeader.Substring("Bearer ".Length).Trim();
            FirebaseToken? decodedToken = await VerifyFirebaseIdToken(idToken);
            return decodedToken;
        }

        private async Task<FirebaseToken?> VerifyFirebaseIdToken(string idToken)
        {
            try
            {
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                return decodedToken;
            }
            catch
            {
                return null;
            }
        }

        public async Task SetUserRoleClaimAsync(string uid, string role, int? businessId)
        {
            var claims = new Dictionary<string, object>()
        {
            { "role", role.ToLower() },
            { "businessId", businessId ?? 0 }
        };

            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(uid, claims);
        }
    }
}
