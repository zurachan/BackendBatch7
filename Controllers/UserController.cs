using BackendBatch7.Attributes;
using BackendBatch7.Domains;
using BackendBatch7.Models;
using BackendBatch7.SearchParam;
using BackendBatch7.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        // GET: api/User
        [HttpGet]
        public Response<List<User>> GetAllUsers() => _userService.GetAllUser();

        // GET: api/User
        [HttpGet("search")]
        public PagedResponse<List<User>> GetUsers([FromQuery] UserSearchParam param) => _userService.GetPaginationUser(param);

        // GET: api/User/5
        [HttpGet("{id}")]
        [Cache]
        public Response<User> GetUser(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        public Response<User> CreateUser(User model) => _userService.CreateUser(model);

        [HttpPut("{id}")]
        public Response<User> UpdateUser(int id, User model) => _userService.UpdateUser(id, model);

        [HttpDelete("{id}")]
        public Response<bool> DeleteUser(int id) => _userService.DeleteUser(id);
    }
}
