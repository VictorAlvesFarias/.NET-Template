namespace Application.Dtos.User.Password
{
    public class ChangePasswordRequest
    {
        public string Passowrd { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

    }
}
