namespace BackendBatch7.Domain.Request
{
    public class AuthenRequest
    {
        public string Email { get; set; } = string.Empty;
    }

    public class SignInRequest : AuthenRequest
    {
        public string Password { get; set; } = string.Empty;
    }

    public class RefreshTokenRequest : AuthenRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
