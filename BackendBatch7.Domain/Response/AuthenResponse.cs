using BackendBatch7.Domain.Entities;

namespace BackendBatch7.Domain.Response;

public class TokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}

public class AuthenResponse : TokenResponse
{
    public UserModel? User { get; set; }
}