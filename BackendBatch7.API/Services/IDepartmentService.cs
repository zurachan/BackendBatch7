using BackendBatch7.API.Models;
using BackendBatch7.API.SearchParam;
using BackendBatch7.Domain;
using BackendBatch7.Infrastructure;

namespace BackendBatch7.API.Services
{
    public interface IDepartmentService
    {
        PagedResponse<List<Department>> GetPaginationDepartment(DepartmentSearchParam param);
        Response<Department> GetDepartmentById(int Id);
        Response<Department> CreateDepartment(Department model);
        Response<Department> UpdateDepartment(int Id, Department model);
        Response<bool> DeleteDepartment(int Id);
    }
    public class DepartmentService(AppDbContext context, IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository) : IDepartmentService
    {
        public PagedResponse<List<Department>> GetPaginationDepartment(DepartmentSearchParam param)
        {
            if (context.Department == null) return new PagedResponse<List<Department>>(null) { Success = false };


            var query = departmentRepository.List(x => string.IsNullOrEmpty(param.Department) ? !x.IsDeleted
            : x.Department_name.Contains(param.Department))
                .OrderByDescending(x => x.Id);

            var pagedData = query.Skip((param.PageNumber - 1) * param.PageSize).Take(param.PageSize).ToList();

            var totalRecords = query.Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, param, totalRecords);
            return pagedReponse;
        }

        public Response<Department> GetDepartmentById(int Id)
        {
            var domain = departmentRepository.FirstOrDefault(x => x.Id == Id);
            if (domain == null) return new Response<Department> { Success = false, Message = "Department not found" };
            return new Response<Department>(domain);
        }

        public Response<Department> CreateDepartment(Department model)
        {
            departmentRepository.Add(model);
            var success = unitOfWork.Commit();

            if (!success) return new Response<Department> { Success = false, Message = "Create Department fail" };
            return new Response<Department>(model);
        }

        public Response<Department> UpdateDepartment(int Id, Department model)
        {
            if (Id != model.Id) return new Response<Department> { Success = false, Message = "Bad request" };
            var domain = departmentRepository.FirstOrDefault(x => x.Id == Id);
            if (domain == null) return new Response<Department> { Success = false, Message = "Department not found" };
            domain.Department_name = model.Department_name;
            domain.UpdatedDate = DateTime.Now;
            departmentRepository.Update(model);
            var success = unitOfWork.Commit();

            if (!success) return new Response<Department> { Success = false, Message = "Update Department fail" };
            return new Response<Department>(model);
        }

        public Response<bool> DeleteDepartment(int Id)
        {
            if (Id == 0) return new Response<bool> { Success = false, Message = "Bad request" };
            var domain = departmentRepository.FirstOrDefault(x => x.Id == Id);
            if (domain == null) return new Response<bool> { Success = false, Message = "Department not found" };
            domain.IsDeleted = true;
            domain.UpdatedDate = DateTime.Now;

            departmentRepository.Delete(domain);
            var success = unitOfWork.Commit();

            if (!success) return new Response<bool> { Success = false, Message = "Delete Department fail" };
            return new Response<bool> { Success = true };
        }
    }
}
