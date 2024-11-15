

using e_commerceApp.Shared.Models;
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
        Task<ApiResponse<UserResponse>> CreateUser(SignUpModel signUpModel);
        Task<User?> GetUserById(Guid userId);
        Task<PaginatedResult<User>> GetAllUsers(int pageNumber, int pageSize);
        //Task<bool> UpdateUser(Guid userId, User updatedUser);
        Task<ApiResponse<UserResponse>> DeleteUser(Guid userId);
        Task<User?> UpdateUser(Guid userId, User updatedUser);
    }
}
