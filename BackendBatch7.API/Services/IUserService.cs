using BackendBatch7.API.Common.Cache;
using BackendBatch7.API.Models;
using BackendBatch7.API.SearchParam;
using BackendBatch7.Domain;
using BackendBatch7.Infrastructure;

namespace BackendBatch7.API.Services
{
    public interface IUserService
    {
        Response<List<User>> GetAllUser();
        PagedResponse<List<User>> GetPaginationUser(UserSearchParam param);
        Response<User> GetUserById(int Id);
        Task<Response<User>> CreateUser(User model);
        Task<Response<User>> UpdateUser(int Id, User model);
        Task<Response<bool>> DeleteUser(int Id);
    }

    public class UserService(AppDbContext context, ICacheService<User> cacheService, IUnitOfWork unitOfWork, IUserRepository userRepository) : IUserService
    {
        public PagedResponse<List<User>> GetPaginationUser(UserSearchParam param)
        {
            if (context.User == null) return new PagedResponse<List<User>>(null) { Success = false };

            var query = userRepository.List(x => string.IsNullOrEmpty(param.User) ? !x.IsDeleted :
                x.First_name.Contains(param.User) || x.Last_name.Contains(param.User) || x.Email.Contains(param.User))
                .OrderByDescending(x => x.Id);

            var pagedData = query.Skip((param.PageNumber - 1) * param.PageSize).Take(param.PageSize).ToList();
            var totalRecords = query.Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, param, totalRecords);
            return pagedReponse;
        }

        public Response<User> GetUserById(int Id)
        {
            var user = userRepository.FirstOrDefault(x => x.Id == Id);
            if (user == null) return new Response<User> { Success = false, Message = "User not found" };
            return new Response<User>(user);
        }

        public async Task<Response<User>> CreateUser(User model)
        {
            var user = userRepository.FirstOrDefault(x => x.Email == model.Email);
            if (user != null) return new Response<User> { Success = false, Message = "User existed" };

            userRepository.Add(model);
            var success = await unitOfWork.CommitAsync();

            if (!success) return new Response<User> { Success = false, Message = "Create User fail" };
            return new Response<User>(model);
        }

        public async Task<Response<User>> UpdateUser(int Id, User model)
        {
            if (Id != model.Id) return new Response<User> { Success = false, Message = "Bad request" };
            var user = userRepository.FirstOrDefault(x => x.Id == Id);
            if (user == null) return new Response<User> { Success = false, Message = "User not found" };

            user.First_name = model.First_name;
            user.Last_name = model.Last_name;
            user.Email = model.Email;
            user.UpdatedBy = model.UpdatedBy;
            userRepository.Update(model);
            var success = await unitOfWork.CommitAsync();

            if (!success) return new Response<User> { Success = false, Message = "Update User fail" };
            return new Response<User>(user);
        }

        public async Task<Response<bool>> DeleteUser(int Id)
        {
            if (Id == 0) return new Response<bool> { Success = false, Message = "Bad request" };
            var user = userRepository.FirstOrDefault(x => x.Id == Id);
            if (user == null) return new Response<bool> { Success = false, Message = "User not found" };

            userRepository.Delete(user);
            var success = await unitOfWork.CommitAsync();

            if (!success) return new Response<bool> { Success = false, Message = "Delete User fail" };
            return new Response<bool> { Success = true };
        }

        public Response<List<User>> GetAllUser()
        {
            var users = userRepository.List(x => !x.IsDeleted);
            return new Response<List<User>>([.. users]);
        }
    }
}
