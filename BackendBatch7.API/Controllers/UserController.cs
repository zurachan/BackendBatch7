using BackendBatch7.API.Models;
using BackendBatch7.API.SearchParam;
using BackendBatch7.API.Services;
using BackendBatch7.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public Response<List<User>> GetAllUsers() => userService.GetAllUser();

        // GET: api/User
        [HttpGet("search")]
        public PagedResponse<List<User>> GetUsers([FromQuery] UserSearchParam param) => userService.GetPaginationUser(param);

        // GET: api/User/5
        [HttpGet("{id}")]
        //[Cache]
        public Response<User> GetUser(int id) => userService.GetUserById(id);

        [HttpPost]
        public Response<User> CreateUser(User model) => userService.CreateUser(model);

        [HttpPut("{id}")]
        public Response<User> UpdateUser(int id, User model) => userService.UpdateUser(id, model);

        [HttpDelete("{id}")]
        public Response<bool> DeleteUser(int id) => userService.DeleteUser(id);
    }
}
