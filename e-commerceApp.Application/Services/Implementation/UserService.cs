using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models.Auth;
using e_commerceApp.Shared.Models.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Data;
namespace e_commerceApp.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger; 
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, ILogger<UserService> logger, IEmailService emailService, IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<ObjectResult> ConfirmEmail(string email, string token)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return new OkObjectResult("Your email has been confirmed successfully.");
                }
            }
            return new BadRequestObjectResult("Something went wrong your email has not been confirmed please try again");
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

                var actionContext = new ActionContext(_httpContextAccessor.HttpContext, new RouteData(), new ActionDescriptor());
                var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);
                var scheme = _httpContextAccessor.HttpContext.Request.Scheme;

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationUrl = urlHelper.Action(nameof(ConfirmEmail), "User", new { token, email = user.Email }, scheme);

                if (confirmationUrl == null)
                {
                    _logger.LogError("Failed to generate confirmation URL.");
                    return new ObjectResult("Failed to generate confirmation URL.") { StatusCode = 500 };
                }

                var message = new Message(new string[] { user.Email }, "Confirmation Email link", confirmationUrl!);
                 _emailService.SendEmail(message);
                return new OkObjectResult($"User has been created successfully, Please confirm your email.");

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

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await GetUserById(userId);
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<List<string>> GetRolesByUser(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return role.ToList();
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user;
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

        public async Task<bool> UpdateUser(int userId, User updatedUser)
        {
            var user = await GetUserById(userId);
            if (user == null) return false;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Address = updatedUser.Address;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.IsActive = updatedUser.IsActive;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
