using BackendBatch7.API.Services;
using BackendBatch7.Domain.Entities;
using BackendBatch7.Domain.Request.SearchParam;
using BackendBatch7.Domain.Response.Base;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService service) : ControllerBase
    {
        // GET: api/Department
        [HttpPost("search")]
        public async Task<PaginatedResponse<List<Department>>> GetDepartments(DepartmentSearchParam param) => await service.GetPaginationDepartment(param);

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<Response<Department>> GetDepartment(int id) => await service.GetDepartmentById(id);

        [HttpPost]
        public async Task<Response<Department>> CreateDepartment(Department model) => await service.CreateDepartment(model);

        [HttpPut("{id}")]
        public async Task<Response<Department>> UpdateDepartment(int id, Department model) => await service.UpdateDepartment(id, model);

        [HttpDelete("{id}")]
        public async Task<Response<bool>> DeleteDepartment(int id) => await service.DeleteDepartment(id);
    }
}
