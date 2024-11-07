using e_commerceApp.Shared.Models;

namespace ecommerce.Client.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient _httpClient;

        public EmployeeServices(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee/getAllEmployee");
            return response ?? new List<Employee>();
        }

        
    }
}
