using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("AllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var success = await _userService.UpdateUser(id, updatedUser);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUser(id);
            if (!success) return NotFound();
            return Ok("User Deleted successfully");
        }
    }
}
