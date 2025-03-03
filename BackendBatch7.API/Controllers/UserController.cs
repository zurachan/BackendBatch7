using BackendBatch7.API.Services;
using BackendBatch7.Domain.Entities;
using BackendBatch7.Domain.Request.SearchParam;
using BackendBatch7.Domain.Response;
using BackendBatch7.Domain.Response.Base;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public async Task<Response<List<User>>> GetAllUsers() => await userService.GetAllUser();

        // GET: api/User
        [HttpPost("search")]
        public async Task<PaginatedResponse<List<UserModel>>> GetUsers(UserSearchParam param) => await userService.GetPaginationUser(param);

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<Response<User>> GetUser(int id) => await userService.GetUserById(id);

        [HttpPost]
        public async Task<Response<UserModel>> CreateUser(UserModel model) => await userService.CreateUser(model);

        [HttpPut("{id}")]
        public async Task<Response<User>> UpdateUser(int id, User model) => await userService.UpdateUser(id, model);

        [HttpDelete("{id}")]
        public async Task<Response<bool>> DeleteUser(int id) => await userService.DeleteUser(id);
    }
}
