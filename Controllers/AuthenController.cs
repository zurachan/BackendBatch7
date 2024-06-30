using BackendBatch7.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        [HttpPost("Login")]
        public Response<AuthenResponse> Login(AuthenRequest model)
        {
            var domains = new List<AuthenRequest>() {
                new() { Email = "duonght@gmail.com", Password= "123456" },
                new() { Email = "thaotp@gmail.com", Password= "123456" },
            };

            var user = domains.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null) return new Response<AuthenResponse>(null) { Success = false };

            return new Response<AuthenResponse>(new AuthenResponse { Token = "daylatoken" }) { Success = true };
        }
    }
}
