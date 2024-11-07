using e_commerceApp.Shared.Models;

namespace ecommerce.Client.Implementations
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetAllEmployeeAsync();
    }
}
