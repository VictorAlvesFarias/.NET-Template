using Application.Dtos.Default;
using Application.Dtos.User.Create;
using Application.Dtos.User.Login;
using Application.Dtos.User.Password;
using Application.Dtos.User.Put;
using Domain.Entitites;
using System;

namespace Application.Services.Identity
{
    public interface IIdentityService
    {
        Task<BaseResponse<LoginUserResponse>> LoginAsync(LoginUserRequest loginData);
        Task<DefaultResponse> AddUser(CreateUserRequest userData);
        Task<DefaultResponse> DeleteUser(LoginUserRequest email);
        Task<DefaultResponse> PutUser(PutUserRequest userData);
        Task<DefaultResponse> ValidateUsernameAsync(string email);
        Task<DefaultResponse> ValidateEmailAsync(string email);
        Task<DefaultResponse> ChangePasswordAsync(ChangePasswordRequest changePasswordData);
    }
}
