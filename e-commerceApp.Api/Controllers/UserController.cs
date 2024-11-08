using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, ITokenService tokenService, UserManager<User> userManager, IEmailService emailService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] SignUpModel signUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _userService.CreateUser(signUp);
            return result;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInModel signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //check if a user exists with the provided username and password
            var user = await _userService.AuthenticateUser(signIn.Email, signIn.Password);
            //if user credentials are not authentic return bad request with a message 
            if (user == null)
            {
                return this.Problem("Email or password is incorrect", statusCode: 400);
            }

            //get roles
            var roles = await _userService.GetRolesByUser(user);

            //generate a jwt token
            var token = _tokenService.GenerateToken(user, roles);

            //return token in the response
            return Ok(new { Token = token });
        }
        [HttpGet]
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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("AllUsers")]
        [Authorize]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var success = await _userService.UpdateUser(id, updatedUser);
            if (!success) return NotFound();
            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUser(id);
            if (!success) return NotFound();
            return Ok("User Deleted successfully");
        }

        [Authorize]
        [HttpGet("get-signed-in-user")]
        public IActionResult GetSignedInUser()
        {
            var currentUser = HttpContext.User;
            var firstName = currentUser.Claims.FirstOrDefault(c => c.Type == "firstName").Value;
            var lastName = currentUser.Claims.FirstOrDefault(c => c.Type == "lastName").Value;

            var phone = currentUser.Claims.FirstOrDefault(c => c.Type == "phoneNumber").Value;

            var isAdmin = false;
            if (currentUser.HasClaim(c => c.Type == ClaimTypes.Role))
                isAdmin = true;

            return Ok(new { FirstName = firstName, LastName = lastName, Phone = phone, IsAdmin = isAdmin });
        }
    }
}
