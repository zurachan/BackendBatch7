using BackendBatch7.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [HttpGet]
        public Response<bool> CheckPermission()
        {
            return new Response<bool>(true);
        }
    }
}
