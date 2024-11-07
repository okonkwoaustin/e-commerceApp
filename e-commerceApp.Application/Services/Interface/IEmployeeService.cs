using e_commerceApp.Application.Dto;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployee(Employee employee);
        Task DeleteEmployeeByIdAsync(int id);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<PagedResult<Employee>> GetPagedEmployeesAsync(int pageNumber, int pageSize);
        //Task<PagedResult<Employee>> GetPagedEmployeesAsync(int pageNumber, int pageSize, string searchTerm, string sortBy, bool descending);
    }
}
