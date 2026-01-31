using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QFlick.Application.Interfaces;
using QFlick.Domain.DTOs.Auth;

namespace QFlick_WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IValidator<LoginInputDto> validator) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        private readonly IValidator<LoginInputDto> _validator = validator;

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginInputDto UserData, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(UserData);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _authService.Login(UserData, cancellationToken);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
