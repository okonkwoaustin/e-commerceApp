using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
namespace e_commerceApp.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public async Task<User> AuthenticateUser(string email, string password)
        {
            try
            {
                var existingUser = await GetUserIfExists(email);
                if (existingUser != null)
                {
                    existingUser = await CheckPassword(existingUser, password);
                }
                return existingUser;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error authenticating user: {ex.Message} {ex.StackTrace}");
                throw;
            }
        }

        public async Task<User> CheckPassword(User user, string password)
        {
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidOperationException("Invalid Credentials");
            }
            await _signInManager.SignInAsync(user, false);
            return user;
        }

        public Task<ObjectResult> ConfirmEmail(string email, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ObjectResult> CreateUser(SignUpModel signUpModel)
        {
            try
            {
                // Check if the 'User' role exists
                var role = await _roleManager.FindByNameAsync("User");
                if (role == null)
                {
                    _logger.LogError("Role 'User' does not exist.");
                    return new BadRequestObjectResult("Role 'User' does not exist. Please contact support.");
                }

                var user = new User
                {
                    Email = signUpModel.Email,
                    UserName = signUpModel.Email,
                    FirstName = signUpModel.FirstName,
                    LastName = signUpModel.LastName,
                };

                // Attempt to create the user
                var creationResult = await _userManager.CreateAsync(user, signUpModel.Password);
                if (!creationResult.Succeeded)
                {
                    var errorDescriptions = string.Join(", ", creationResult.Errors.Select(e => e.Description));
                    _logger.LogError($"User creation failed: {errorDescriptions}");
                    return new UnprocessableEntityObjectResult($"User creation failed: {errorDescriptions}");
                }

                // Attempt to assign the 'User' role
                var roleAssignmentResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleAssignmentResult.Succeeded)
                {
                    var roleErrorDescriptions = string.Join(", ", roleAssignmentResult.Errors.Select(e => e.Description));
                    _logger.LogError($"Role assignment failed: {roleErrorDescriptions}");
                    return new UnprocessableEntityObjectResult($"Role assignment failed: {roleErrorDescriptions}");
                }


                _logger.LogInformation("User created and role assigned successfully.");
                return new OkObjectResult(new { Message = "User created successfully" });
            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred while creating a user.");
                return new ObjectResult("An unexpected error occurred while creating the user.")
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<List<string>> GetRolesByUser(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return role.ToList();
        }

        public async Task<User> GetUserIfExists(string email)
        {
            User user = null;
            try
            {
                user = await _userManager.FindByEmailAsync(email);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} {ex.StackTrace}");
                throw;
            }
        }
    }
}
