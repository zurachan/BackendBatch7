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
        private IUserService _userService = userService;

        // GET: api/User
        [HttpPost("search")]
        public PagedResponse<List<User>> GetUsers(UserSearchParam param) => _userService.GetPaginationUser(param);

        // GET: api/User/5
        [HttpGet("{id}")]
        public Response<User> GetUser(int id) => _userService.GetUserById(id);

        [HttpPost]
        public Response<User> CreateUser(User model) => _userService.CreateUser(model);

        [HttpPut("{id}")]
        public Response<User> UpdateUser(int id, User model) => _userService.UpdateUser(id, model);

        [HttpDelete("{id}")]
        public Response<bool> DeleteUser(int id) => _userService.DeleteUser(id);
    }
}
