using Application.Dtos.Default;
using Application.Dtos.User.Create;
using Application.Dtos.User.Login;
using Application.Dtos.User.Password;
using Application.Dtos.User.Put;
using Application.Dtos.User.Validate;
using Application.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Template.Controllers
{
    public class UserController : Controller
    {

        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("/create-user")]
        public async Task<ActionResult<DefaultResponse>> CreateUser([FromBody] CreateUserRequest userData)
        {
            var result = await _identityService.AddUser(userData);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("/sign-in")]
        public async Task<ActionResult<BaseResponse<LoginUserResponse>>> LoginUser([FromBody] LoginUserRequest loginData)
        {
            var result = await _identityService.LoginAsync(loginData);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize]
        [HttpDelete("/delete-account")]
        public async Task<ActionResult<DefaultResponse>> DeleteUser([FromBody] LoginUserRequest loginData)
        {
            var result = await _identityService.DeleteUser(loginData);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize]
        [HttpPut("/update-account")]
        public async Task<ActionResult<DefaultResponse>> UpdateUser([FromBody] PutUserRequest userData)
        {
            var result = await _identityService.PutUser(userData);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("/validade-email")]
        public async Task<ActionResult<DefaultResponse>> ValidateEmail([FromBody] ValidateEmailRequest validate)
        {
            var result = await _identityService.ValidateEmailAsync(validate.Email);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("/validate-username")]
        public async Task<ActionResult<DefaultResponse>> ValidateUsername([FromBody] ValidateUsernameRequest validate)
        {
            var result = await _identityService.ValidateUsernameAsync(validate.Username);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize]
        [HttpPost("/change-password")]
        public async Task<ActionResult<DefaultResponse>> ChangePassword([FromBody] ChangePasswordRequest changePasswordData)
        {
            var result = await _identityService.ChangePasswordAsync(changePasswordData);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
