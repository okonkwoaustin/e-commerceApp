using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("getAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var data = await _employeeService.GetAllEmployeeAsync();
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Create(Employee employee)
        {
            return Ok(_employeeService.AddEmployee(employee));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           return Ok(await _employeeService.GetEmployeeByIdAsync(id));
        }
        [HttpPost("UpdateEmployee")]
        public async Task<IActionResult> Edit(Employee employee, int id)
        {
                return Ok(await _employeeService.UpdateEmployee(id, employee));
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(_employeeService.DeleteEmployeeByIdAsync(id));
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedEmployees(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            var result = await _employeeService.GetPagedEmployeesAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}
