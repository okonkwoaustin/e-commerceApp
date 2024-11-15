using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using e_commerceApp.Shared.Models.Dtos;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger; 
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<UserService> logger, IEmailService emailService, IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
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

        public async Task<ApiResponse<UserResponse>> CreateUser(SignUpModel signUpModel)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(signUpModel.Email);
                if (existingUser != null)
                {
                    return new ApiResponse<UserResponse>
                    {
                        Message = "User already exist",
                        StatusCode = 403,
                        IsSuccess = false
                    };
                }
                // Check if the 'User' role exists
                var role = await _roleManager.FindByNameAsync("User");
                if (role == null)
                {
                    return new ApiResponse<UserResponse>
                    {
                        Message = "Role 'User' does not exist. Please contact support.",
                        StatusCode = 403,
                        IsSuccess = false
                    };
                }

                User user = new User
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
                    return new ApiResponse<UserResponse>
                    {
                        Message = "User creation failed",
                        StatusCode = 403,
                        IsSuccess = false
                    };
                }

                // Attempt to assign the 'User' role
                var roleAssignmentResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleAssignmentResult.Succeeded)
                {
                    return new ApiResponse<UserResponse>
                    {
                        Message = "Role assignment failed.",
                        StatusCode = 403,
                        IsSuccess = false
                    };
                }
                
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                return new ApiResponse<UserResponse>
                {
                    Message = $"User created successfully, Please go to your email {user.Email} and verify.",
                    StatusCode = 201,
                    IsSuccess = true,
                    ResponseRequest = new UserResponse
                    {
                        Token = token,
                        User = user
                    }
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error authenticating user: {ex.Message} {ex.StackTrace}");
                throw;
            }
        }

        public async Task<ApiResponse<UserResponse>> DeleteUser(Guid userId)
        {
            var user = await GetUserById(userId);
            if (user == null)
                return new ApiResponse<UserResponse>
                {
                    StatusCode = 404,
                    Message = "User does not exist",
                    IsSuccess = false
                };
            var result = await _userManager.DeleteAsync(user);
            return new ApiResponse<UserResponse>
            {
                Message = "User deleted successfully",
                StatusCode = 200,
                IsSuccess = result.Succeeded,
            };
        }

        public async Task<PaginatedResult<User>> GetAllUsers(int pageNumber, int pageSize)
        {
            var skipResult = (pageNumber - 1) * pageSize;
            var totalUsers = await _userManager.Users.CountAsync();
            var users = await _userManager.Users
                                          .Skip(skipResult)
                                          .Take(pageSize)
                                          .ToListAsync();

            return new PaginatedResult<User>
            {
                Items = users,
                TotalCount = totalUsers,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<string>> GetRolesByUser(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return role.ToList();
        }

        public async Task<User?> GetUserById(Guid userId)
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

        public async Task<User?> UpdateUser(Guid userId, User updatedUser)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return null;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;

            await _userManager.UpdateAsync(user);
            return user;
        }

        public UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public User MapToUser(SignUpModel signUpModel)
        {
            return new User
            {
                UserName = signUpModel.Email,
                Email = signUpModel.Email,
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName
            };
        }
    }
}
