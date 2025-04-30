using Application.Dtos.Default;
using Application.Dtos.User.Create;
using Application.Dtos.User.Login;
using Application.Dtos.User.Password;
using Application.Dtos.User.Put;
using Application.Dtos.User.Validate;
using Application.Services.Identity;
using ASP.NET_Core_Template.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
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

            return this.DefaultResult(result);
        }

        [HttpPost("/sign-in")]
        public async Task<ActionResult<BaseResponse<LoginUserResponse>>> LoginUser([FromBody] LoginUserRequest loginData)
        {
            var result = await _identityService.LoginAsync(loginData);

            return this.Result<LoginUserResponse>(result);
        }

        [Authorize]
        [HttpDelete("/delete-account")]
        public async Task<ActionResult<DefaultResponse>> DeleteUser([FromBody] LoginUserRequest loginData)
        {
            var result = await _identityService.DeleteUser(loginData);

            return this.DefaultResult(result);
        }

        [Authorize]
        [HttpPut("/update-account")]
        public async Task<ActionResult<DefaultResponse>> UpdateUser([FromBody] PutUserRequest userData)
        {
            var result = await _identityService.PutUser(userData);

            return this.DefaultResult(result);
        }

        [HttpPost("/validade-email")]
        public async Task<ActionResult<DefaultResponse>> ValidateEmail([FromBody] ValidateEmailRequest validate)
        {
            var result = await _identityService.ValidateEmailAsync(validate.Email);

            return this.DefaultResult(result);
        }

        [HttpPost("/validate-username")]
        public async Task<ActionResult<DefaultResponse>> ValidateUsername([FromBody] ValidateUsernameRequest validate)
        {
            var result = await _identityService.ValidateUsernameAsync(validate.Username);

            return this.DefaultResult(result);
        }

        [Authorize]
        [HttpPost("/change-password")]
        public async Task<ActionResult<DefaultResponse>> ChangePassword([FromBody] ChangePasswordRequest changePasswordData)
        {
            var result = await _identityService.ChangePasswordAsync(changePasswordData);

            return this.DefaultResult(result);
        }
    }
}
