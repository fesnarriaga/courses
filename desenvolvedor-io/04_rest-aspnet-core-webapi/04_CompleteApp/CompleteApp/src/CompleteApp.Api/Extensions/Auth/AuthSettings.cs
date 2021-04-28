namespace CompleteApp.Api.Extensions.Auth
{
    public class AuthSettings
    {
        public string Secret { get; set; }

        public int ExpiresIn { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
