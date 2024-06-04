using BackendBatch7.Common.Cache;
using BackendBatch7.Common.CacheHelper;
using BackendBatch7.Domains;
using BackendBatch7.Models;
using BackendBatch7.SearchParam;

namespace BackendBatch7.Services
{
    public interface IDepartmentService
    {
        PagedResponse<List<Department>> GetPaginationDepartment(DepartmentSearchParam param);
        Response<Department> GetDepartmentById(int Id);
        Response<Department> CreateDepartment(Department model);
        Response<Department> UpdateDepartment(int Id, Department model);
        Response<bool> DeleteDepartment(int Id);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;
        private readonly ICacheService<Department> _cacheService;

        public DepartmentService(AppDbContext context, ICacheService<Department> cacheService)
        {
            _context = context;
            _cacheService = cacheService;
            GetCacheDepartment();
        }

        public PagedResponse<List<Department>> GetPaginationDepartment(DepartmentSearchParam param)
        {
            if (GetCacheDepartment() == null)
            {
                return new PagedResponse<List<Department>>(null) { Success = false };
            }

            var query = GetCacheDepartment()
                .Where(x => !string.IsNullOrEmpty(param.Department) ? x.Department_name.Contains(param.Department) : !x.IsDeleted)
                .OrderByDescending(x => x.Id);

            var pagedData = query.Skip((param.PageNumber - 1) * param.PageSize).Take(param.PageSize).ToList();

            var totalRecords = query.Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, param, totalRecords);
            return pagedReponse;
        }

        public Response<Department> GetDepartmentById(int Id)
        {
            var domain = GetCacheDepartment().FirstOrDefault(x => x.Id == Id);
            if (domain == null)
                return new Response<Department> { Success = false, Message = "Department not found" };
            return new Response<Department>(domain);
        }

        public Response<Department> CreateDepartment(Department model)
        {
            _context.Department.Add(model);
            _context.SaveChanges();
            return new Response<Department>(model);

        }

        public Response<Department> UpdateDepartment(int Id, Department model)
        {
            if (Id != model.Id)
                return new Response<Department> { Success = false, Message = "Bad request" };
            var domain = GetCacheDepartment().FirstOrDefault(x => x.Id == Id);
            if (domain == null)
                return new Response<Department> { Success = false, Message = "Department not found" };
            domain.Department_name = model.Department_name;
            domain.Updated_date = DateTime.Now;
            _context.Update(domain);
            _context.SaveChanges();
            return new Response<Department>(domain);
        }

        public Response<bool> DeleteDepartment(int Id)
        {
            if (Id == 0) return new Response<bool> { Success = false, Message = "Bad request" };
            var domain = GetCacheDepartment().FirstOrDefault(x => x.Id == Id);
            if (domain == null)
                return new Response<bool> { Success = false, Message = "Department not found" };
            domain.IsDeleted = true;
            domain.Updated_date = DateTime.Now;
            _context.Update(domain);
            _context.SaveChanges();
            return new Response<bool> { Success = true };
        }
        private List<Department> GetCacheDepartment()
        {
            return _cacheService.Get(CacheKeys.Departments);
        }
    }
}
