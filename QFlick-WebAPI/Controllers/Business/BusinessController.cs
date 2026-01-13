using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QFlick.Application.Abstractions;
using QFlick.Application.Interfaces;
using QFlick.Domain.DTOs.Business;

namespace QFlick_WebAPI.Controllers.Business
{
    [Route("api/[controller]")]
    [Authorize(Roles = "business-admin")]
    [ApiController]
    public class BusinessController(IBusinessService businessService, IAuthService authService) : ControllerBase
    {
        private readonly IBusinessService _businessService = businessService;
        private readonly IAuthService _authService = authService;

        [HttpPost("switch-business/{newHBusinessId}")]
        public async Task<IActionResult> SwitchBsuiness(int newBusinessId)
        {
            var userId = User.FindFirst("user_id")?.Value;

            bool IsOwnBusiness = await _businessService.IsOwnBusiness(userId!, newBusinessId);

            if (IsOwnBusiness) return BadRequest("User ID not found in token.");

            await _authService.SetUserRoleClaimAsync(userId!, "business-admin", newBusinessId);

            return Ok(new { message = "Business switched! Please refresh token." });
        }

        [HttpPost("add-business")]
        public async Task<IActionResult> CreateBusiness([FromBody] CreateBusinessInputDto businessData, CancellationToken cancellationToken)
        {

            await _businessService.CreateBusiness(businessData, cancellationToken);
            return Ok(new { message = "Business created successfully!" });
        }
    }
}
