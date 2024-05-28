using BackendBatch7.Domains;
using BackendBatch7.Models;
using BackendBatch7.SearchParam;

namespace BackendBatch7.Services
{
    public interface IUserService
    {
        PagedResponse<List<User>> GetPaginationUser(UserSearchParam param);
        Response<User> GetUserById(int Id);
        Response<User> CreateUser(User model);
        Response<User> UpdateUser(int Id, User model);
        Response<bool> DeleteUser(int Id);
    }

    public class UserService(AppDbContext context) : IUserService
    {
        private readonly AppDbContext _context = context;

        public PagedResponse<List<User>> GetPaginationUser(UserSearchParam param)
        {
            if (_context.User == null)
            {
                return new PagedResponse<List<User>>(null) { Success = false };
            }
            var validFilter = new UserSearchParam(param.PageNumber, param.PageSize);

            var query = _context.User
                .Where(x => !string.IsNullOrEmpty(param.User) ? !x.IsDeleted &&
                (x.First_name.Contains(param.User) || x.Last_name.Contains(param.User) || x.Email.Contains(param.User)) : !x.IsDeleted)
                .OrderByDescending(x => x.Id);

            var pagedData = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();

            var totalRecords = query.Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, totalRecords);
            return pagedReponse;
        }

        public Response<User> GetUserById(int Id)
        {
            var user = _context.User.Find(Id);
            if (user == null)
                return new Response<User> { Success = false, Message = "User not found" };
            return new Response<User>(user);
        }

        public Response<User> CreateUser(User model)
        {
            var user = _context.User.FirstOrDefault(x => x.Email == model.Email);
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
            var user = _context.User.Find(Id);
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
            var user = _context.User.Find(Id);
            if (user == null)
                return new Response<bool> { Success = false, Message = "User not found" };
            user.IsDeleted = true;
            user.Updated_date = DateTime.Now;
            _context.Update(user);
            _context.SaveChanges();
            return new Response<bool> { Success = true };
        }
    }
}
