namespace CompleteApp.Api.ViewModels.Identity
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }

        public double ExpiresIn { get; set; }

        public UserResponseViewModel User { get; set; }
    }
}
