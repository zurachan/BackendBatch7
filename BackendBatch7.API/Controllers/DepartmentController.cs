﻿using BackendBatch7.API.Models;
using BackendBatch7.API.SearchParam;
using BackendBatch7.API.Services;
using BackendBatch7.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackendBatch7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService departmentService) : ControllerBase
    {
        private readonly IDepartmentService _departmentService = departmentService;

        // GET: api/Department
        [HttpGet("search")]
        public PagedResponse<List<Department>> GetDepartments([FromQuery] DepartmentSearchParam param) => _departmentService.GetPaginationDepartment(param);

        // GET: api/Department/5
        [HttpGet("{id}")]
        public Response<Department> GetDepartment(int id) => _departmentService.GetDepartmentById(id);

        [HttpPost]
        public Response<Department> CreateDepartment(Department model) => _departmentService.CreateDepartment(model);

        [HttpPut("{id}")]
        public Response<Department> UpdateDepartment(int id, Department model) => _departmentService.UpdateDepartment(id, model);

        [HttpDelete("{id}")]
        public Response<bool> DeleteDepartment(int id) => _departmentService.DeleteDepartment(id);
    }
}
