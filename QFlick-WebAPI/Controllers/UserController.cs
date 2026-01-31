using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QFlick.Application.Abstractions;
using QFlick.Application.Exceptions;
using QFlick.Application.Interfaces;
using QFlick.Domain.Consts;
using QFlick.Domain.DTOs;
using QFlick.Domain.DTOs.Client;

namespace QFlick_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, IAuthService authService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IAuthService _authService = authService;

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddUser([FromBody] RegCustomerDto user, CancellationToken cancellationToken)
        {
            //var userId = User.FindFirst("user_id")?.Value;
            await _userService.AddNewCustomer(user, cancellationToken);
            return Ok();
        }

        [HttpPost("add-business")]
        public async Task<IActionResult> AddBusiness([FromBody] BusinessRegisterDto user, CancellationToken cancellationToken)
        {
            await _userService.AddNewBusiness(user, cancellationToken);
            return Ok();
        }

        [HttpGet("user-detail")]
        [Authorize(Roles = "business")]
        public async Task<ActionResult<AppUserDto>> GetUserDetail(string userId, CancellationToken cancellationToken)
        {
            AppUserDto user = await _userService.GetUserDetailAsync(userId);
            return Ok(user);
        }

        [HttpGet("error-demo")]
        public async Task<ActionResult<AppUserDto>> GetError()
        {
            try
            {
                throw new NotFoundException(ResponseMessage.USER_NOT_FOUND);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
 }
