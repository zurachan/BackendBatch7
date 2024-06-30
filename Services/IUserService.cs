using BackendBatch7.Common.Cache;
using BackendBatch7.Common.CacheHelper;
using BackendBatch7.Domains;
using BackendBatch7.Models;
using BackendBatch7.SearchParam;

namespace BackendBatch7.Services
{
    public interface IUserService
    {
        Response<List<User>> GetAllUser();
        PagedResponse<List<User>> GetPaginationUser(UserSearchParam param);
        Response<User> GetUserById(int Id);
        Response<User> CreateUser(User model);
        Response<User> UpdateUser(int Id, User model);
        Response<bool> DeleteUser(int Id);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly ICacheService<User> _cacheService;

        public UserService(AppDbContext context, ICacheService<User> cacheService)
        {
            _context = context;
            _cacheService = cacheService;
            GetCacheUser();
        }

        public PagedResponse<List<User>> GetPaginationUser(UserSearchParam param)
        {
            if (_context.User == null)
            {
                return new PagedResponse<List<User>>(null) { Success = false };
            }
            var query = GetCacheUser().Where(x => string.IsNullOrEmpty(param.User) ? !x.IsDeleted :
            (x.First_name.Contains(param.User) || x.Last_name.Contains(param.User) || x.Email.Contains(param.User)))
                .OrderByDescending(x => x.Id);

            var pagedData = query.Skip((param.PageNumber - 1) * param.PageSize).Take(param.PageSize).ToList();
            var totalRecords = query.Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, param, totalRecords);
            return pagedReponse;
        }

        public Response<User> GetUserById(int Id)
        {
            var user = GetCacheUser().FirstOrDefault(x => x.Id == Id);
            if (user == null)
                return new Response<User> { Success = false, Message = "User not found" };
            return new Response<User>(user);
        }

        public Response<User> CreateUser(User model)
        {
            var user = GetCacheUser().FirstOrDefault(x => x.Email == model.Email);
            if (user != null)
                return new Response<User> { Success = false, Message = "User existed" };
            _context.User.Add(model);
            _context.SaveChanges();
            return new Response<User>(model);

        }

        public Response<User> UpdateUser(int Id, User model)
        {
            if (Id != model.Id)
                return new Response<User> { Success = false, Message = "Bad request" };
            var user = GetCacheUser().FirstOrDefault(x => x.Id == Id);
            if (user == null)
                return new Response<User> { Success = false, Message = "User not found" };
            user.First_name = model.First_name;
            user.Last_name = model.Last_name;
            user.Email = model.Email;
            user.Updated_date = DateTime.Now;
            _context.Update(user);
            _context.SaveChanges();
            return new Response<User>(user);
        }

        public Response<bool> DeleteUser(int Id)
        {
            if (Id == 0) return new Response<bool> { Success = false, Message = "Bad request" };
            var user = GetCacheUser().FirstOrDefault(x => x.Id == Id);
            if (user == null)
                return new Response<bool> { Success = false, Message = "User not found" };
            user.IsDeleted = true;
            user.Updated_date = DateTime.Now;
            _context.Update(user);
            _context.SaveChanges();
            return new Response<bool> { Success = true };
        }

        private List<User> GetCacheUser()
        {
            return _cacheService.Get(CacheKeys.Users);
        }

        public Response<List<User>> GetAllUser()
        {
            var users = GetCacheUser();
            return new Response<List<User>>(users);
        }
    }

}
