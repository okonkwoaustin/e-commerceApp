using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Application.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EcommDbContext _ecommDbContext;

        public EmployeeService(EcommDbContext ecommDbContext)
        {
            _ecommDbContext = ecommDbContext;
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employeeDetails = await _ecommDbContext.Employees
                .FirstOrDefaultAsync(u => u.Id == id);
            if(employeeDetails == null)
            {
                return null;
            }
            return employeeDetails;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var employeeDetail = await _ecommDbContext.Employees.OrderBy(u => u.DateCreated)
                .ToListAsync();
            return employeeDetail;
        }

        public async Task<PagedResult<Employee>> GetPagedEmployeesAsync(int pageNumber, int pageSize)
        {
            // Calculate the skip value based on the pageNumber and pageSize
            int skip = (pageNumber - 1) * pageSize;

            // Get the paged result
            var products = await _ecommDbContext.Employees 
                .Skip(skip)               
                .Take(pageSize)          
                .ToListAsync();

            var totalCount = await _ecommDbContext.Employees.CountAsync();
            return new PagedResult<Employee>
            {
                TotalCount = totalCount,
                Items = products
            };
        }


        public async Task DeleteEmployeeByIdAsync(int id)
        {
            var employeeDetail = await _ecommDbContext.Employees
               .FirstOrDefaultAsync(u => u.Id == id);
            if (employeeDetail != null)
            {
                _ecommDbContext.Employees.Remove(employeeDetail);
                _ecommDbContext.SaveChanges();
            }
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            var addEmployee = await _ecommDbContext.Employees.AddAsync(employee);
            var affectedRows = await _ecommDbContext.SaveChangesAsync();
            if (affectedRows == 0)
            {
                return 0;
            }
            return addEmployee.Entity.Id; 
        }


        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var getEmployee = await _ecommDbContext.Employees.FirstOrDefaultAsync(u => u.Id == id);
            if (getEmployee == null)
            {
                return null;
            }
            _ecommDbContext.Employees.Update(employee);
            return employee;
        }

    }
}
