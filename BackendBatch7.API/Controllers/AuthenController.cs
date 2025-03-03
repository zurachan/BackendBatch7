using BackendBatch7.Domain.Request;
using BackendBatch7.Domain.Response;
using BackendBatch7.Domain.Response.Base;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [HttpPost("Login")]
        public Response<AuthenResponse> Login(SignInRequest model)
        {
            var domains = new List<SignInRequest>() {
                new() { Email = "duonght@gmail.com", Password= "123456" },
                new() { Email = "thaotp@gmail.com", Password= "123456" },
            };

            var user = domains.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null) return new() { Message = "Account does not exist!" };

            return new(new AuthenResponse { AccessToken = "Đây là access token", RefreshToken = "Đây là refresh token" });
        }
    }
}
