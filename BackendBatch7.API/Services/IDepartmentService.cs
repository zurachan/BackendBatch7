using AutoMapper;
using BackendBatch7.Domain.Entities;
using BackendBatch7.Domain.Request.SearchParam;
using BackendBatch7.Domain.Response.Base;
using BackendBatch7.Infrastructure.Core.Interfaces;
using BackendBatch7.Infrastructure.Helpers;
using BackendBatch7.Infrastructure.Interfaces;

namespace BackendBatch7.API.Services
{
    public interface IDepartmentService
    {
        Task<PaginatedResponse<List<Department>>> GetPaginationDepartment(DepartmentSearchParam param);
        Task<Response<Department>> GetDepartmentById(int Id);
        Task<Response<Department>> CreateDepartment(Department model);
        Task<Response<Department>> UpdateDepartment(int Id, Department model);
        Task<Response<bool>> DeleteDepartment(int Id);
    }
    public class DepartmentService(IUnitOfWork unit, IDepartmentRepo departmentRepo, IMapper mapper) : IDepartmentService
    {
        public async Task<PaginatedResponse<List<Department>>> GetPaginationDepartment(DepartmentSearchParam param)
        {
            var query = await departmentRepo.ListNoTrackingAsync(x => !x.IsDeleted);
            if (!string.IsNullOrWhiteSpace(param.SearchText)) query = query.Where(x => x.Department_name.Contains(param.SearchText));
            return await query.ToPagedResponse<Department, Department>(param, mapper, x => x.Id);
        }

        public async Task<Response<Department>> GetDepartmentById(int Id)
        {
            var domain = await departmentRepo.FindNoTrackingAsync(x => x.Id == Id);
            if (domain == null) return new() { Message = "Department not found" };
            return new(domain);
        }

        public async Task<Response<Department>> CreateDepartment(Department model)
        {
            var success = await unit.ExecuteInTransactionAsync(async () => await departmentRepo.AddAsync(model));
            if (!success) return new() { Message = "Create Department fail" };
            return new(model);
        }

        public async Task<Response<Department>> UpdateDepartment(int Id, Department model)
        {
            if (Id != model.Id) return new Response<Department> { Message = "Bad request" };
            var domain = await departmentRepo.FindAsync(x => x.Id == Id && !x.IsDeleted);
            if (domain == null) return new Response<Department> { Message = "Department not found" };
            domain.Department_name = model.Department_name;
            var success = await unit.ExecuteInTransactionAsync(async () => await departmentRepo.UpdateAsync(model));
            if (!success) return new() { Message = "Update Department fail" };
            return new(model);
        }

        public async Task<Response<bool>> DeleteDepartment(int Id)
        {
            if (Id == 0) return new() { Message = "Bad request" };
            var domain = await departmentRepo.FindAsync(x => x.Id == Id);
            if (domain == null) return new Response<bool> { Message = "Department not found" };
            var success = await unit.ExecuteInTransactionAsync(async () => await departmentRepo.DeleteAsync(domain));
            if (!success) return new() { Message = "Delete Department fail" };
            return new(true);
        }
    }
}
