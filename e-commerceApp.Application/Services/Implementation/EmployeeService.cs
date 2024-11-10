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
            getEmployee.FullName = employee.FullName ?? getEmployee.FullName;
            getEmployee.DateOfBirth = employee.DateOfBirth == default ? getEmployee.DateOfBirth : employee.DateOfBirth;
            getEmployee.PhoneNumber = employee.PhoneNumber ?? getEmployee.PhoneNumber;
            getEmployee.Age = employee.Age == 0 ? getEmployee.Age : employee.Age;
            getEmployee.Department = employee.Department ?? getEmployee.Department;

            _ecommDbContext.Employees.Update(getEmployee);
            await _ecommDbContext.SaveChangesAsync();
            return employee;
        }
        //public async Task<bool> ImportEmployee(List<Employee> employees)
        //{
        //    List<Employee> listEmploy = new List<Employee>();
        //    foreach (Employee employee in employees)
        //    {
        //        Employee employ = new Employee
        //        {
        //            FullName = employee.FullName,
        //            DateCreated = DateTime.Now,
        //            Age = employee.Age,
        //            DateOfBirth = employee.DateOfBirth,
        //            Department = employee.Department,
        //            PhoneNumber = employee.PhoneNumber,
        //        };
        //        listEmploy.Add(employee);
        //    }
        //    await _ecommDbContext.BulkInsertAsync();
        //    await _ecommDbContext.SaveChangesAsync();
        //    return listEmploy.Any();
        //}
    }
}
