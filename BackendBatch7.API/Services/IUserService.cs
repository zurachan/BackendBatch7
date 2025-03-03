using AutoMapper;
using BackendBatch7.Domain.Entities;
using BackendBatch7.Domain.Request.SearchParam;
using BackendBatch7.Domain.Response;
using BackendBatch7.Domain.Response.Base;
using BackendBatch7.Infrastructure.Core.Interfaces;
using BackendBatch7.Infrastructure.Helpers;
using BackendBatch7.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.API.Services
{
    public interface IUserService
    {
        Task<Response<List<User>>> GetAllUser();
        Task<PaginatedResponse<List<UserModel>>> GetPaginationUser(UserSearchParam param);
        Task<Response<User>> GetUserById(int Id);
        Task<Response<UserModel>> CreateUser(UserModel model);
        Task<Response<User>> UpdateUser(int Id, User model);
        Task<Response<bool>> DeleteUser(int Id);
    }

    public class UserService(IUnitOfWork unit, IUserRepo userRepo, IMapper mapper) : IUserService
    {
        public async Task<PaginatedResponse<List<UserModel>>> GetPaginationUser(UserSearchParam param)
        {
            var que = await userRepo.ListNoTrackingAsync(x => !x.IsDeleted);
            if (!string.IsNullOrWhiteSpace(param.SearchText))
                que = que.Where(x =>
                x.First_name.Contains(param.SearchText) ||
                x.Last_name.Contains(param.SearchText) ||
                x.Email.Contains(param.SearchText));
            return await que.ToPagedResponse<User, UserModel>(param, mapper, x => x.Id);
        }

        public async Task<Response<User>> GetUserById(int Id)
        {
            var domain = await userRepo.FindNoTrackingAsync(x => x.Id == Id && !x.IsDeleted);
            if (domain == null) return new() { Success = false, Message = "User not found" };
            return new(domain);
        }

        public async Task<Response<UserModel>> CreateUser(UserModel model)
        {
            var domain = await userRepo.FindNoTrackingAsync(x => x.Email == model.Email && !x.IsDeleted);
            if (domain != null) return new() { Message = "User existed" };

            var user = new User
            {
                Id = 0,
                First_name = model.First_name,
                Last_name = model.Last_name,
                Email = model.Email,
            };

            var success = await unit.ExecuteInTransactionAsync(async () => await userRepo.AddAsync(user));
            if (!success) return new() { Message = "Create User fail" };
            model.Id = user.Id;
            return new(model);
        }

        public async Task<Response<User>> UpdateUser(int Id, User model)
        {
            if (Id != model.Id) return new() { Message = "Bad request" };
            var domain = await userRepo.FindAsync(x => x.Id == Id && !x.IsDeleted);
            if (domain == null) return new() { Message = "User not found" };

            domain.First_name = model.First_name;
            domain.Last_name = model.Last_name;
            domain.Email = model.Email;

            var success = await unit.ExecuteInTransactionAsync(async () => await userRepo.UpdateAsync(domain));
            if (!success) return new Response<User> { Success = false, Message = "Update User fail" };
            return new(domain);
        }

        public async Task<Response<bool>> DeleteUser(int Id)
        {
            if (Id == 0) return new() { Message = "Bad request" };
            var user = await userRepo.FindAsync(x => x.Id == Id && !x.IsDeleted);
            if (user == null) return new() { Message = "User not found" };
            var success = await unit.ExecuteInTransactionAsync(async () => await userRepo.DeleteAsync(user));
            if (!success) return new() { Message = "Delete User fail" };
            return new(true);
        }

        public async Task<Response<List<User>>> GetAllUser()
        {
            var users = await userRepo.ListNoTrackingAsync(x => !x.IsDeleted);
            return new(await users.ToListAsync());
        }
    }
}
