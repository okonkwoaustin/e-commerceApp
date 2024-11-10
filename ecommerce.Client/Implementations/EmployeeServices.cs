using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using EFCore.BulkExtensions;

namespace ecommerce.Client.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient _httpClient;
        EcommDbContext _ecomm;
        public EmployeeServices(IHttpClientFactory httpClientFactory, EcommDbContext ecomm)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            _ecomm = ecomm;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee/getAllEmployee");
            return response ?? new List<Employee>();
        }

        public async Task<bool> ImportEmployee(List<Employee> employees)
        {
            List<Employee> listEmploy = new List<Employee>();
            foreach (Employee employee in employees)
            {
                Employee employ = new Employee
                {
                    FullName = employee.FullName,
                    DateCreated = DateTime.Now,
                    Age = employee.Age,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                    PhoneNumber = employee.PhoneNumber,
                };
                listEmploy.Add(employee);
            }
            await _ecomm.BulkInsertAsync(listEmploy);
            await _ecomm.SaveChangesAsync();
            return true;
        }
    }
}
