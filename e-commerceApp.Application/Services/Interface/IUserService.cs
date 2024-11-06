

using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IUserService
    {
        Task<User> GetUserIfExists(string email);
        Task<User> CheckPassword(User user, string password);
        Task<User> AuthenticateUser(string email, string password);
        Task<List<string>> GetRolesByUser(User user);
        Task<ObjectResult> CreateUser(SignUpModel signUpModel);
        public Task<ObjectResult> ConfirmEmail(string email, string token);
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> UpdateUser(int userId, User updatedUser);
        Task<bool> DeleteUser(int userId);
    }
}
