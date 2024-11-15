using AutoMapper;
using e_commerceApp.Application.Configs.CustomActionFilter;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using e_commerceApp.Shared.Models.Dtos;
using e_commerceApp.Shared.Models.Email;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, ITokenService tokenService, UserManager<User> userManager, IEmailService emailService, IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userManager = userManager;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] SignUpModel signUp)
        {
            var tokenResponse = await _userService.CreateUser(signUp);
            if (tokenResponse.IsSuccess)
            {
                var confirmation = Url.Action(nameof(ConfirmEmail), "Auth", new { tokenResponse.ResponseRequest.Token, email = signUp.Email }, Request.Scheme);
                var message = new Message(new string[] { signUp.Email }, "Confirmation Email link", confirmation!);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new ResponseRequest
                    {
                        Message = tokenResponse.Message,
                        Status = "Success"
                    });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                new ResponseRequest
                {
                    Message = tokenResponse.Message,
                    Status = "Error"
                });
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInModel signIn)
        {

            //check if a user exists with the provided username and password
            var user = await _userService.AuthenticateUser(signIn.Email, signIn.Password);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                new ResponseRequest
                {
                    Message = "Email or password is incorrect",
                    Status = "Error"
                });
            }

            //get roles
            var roles = await _userService.GetRolesByUser(user);

            //generate a jwt token
            var token = _tokenService.GenerateToken(user, roles);
            var response = new LoginResponse
            {
                JwtToken = token,
            };
            return Ok(response);
        }

        [HttpGet("Confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, 
                        new ResponseRequest
                    {
                        Message = "Your email has been confirmed successfully.",
                        Status = "Success"
                    });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                new ResponseRequest
                {
                    Message = "This user does not exist",
                    Status = "Error"
                });           
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            var mapresult = _mapper.Map<UserDto>(user);
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        [Authorize]
        public async Task<IActionResult> GetUsers([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            var users = await _userService.GetAllUsers(pageNumber, pageSize);
            var mappedResult = _mapper.Map<PaginatedResult<UserDto>>(users);
            return Ok(mappedResult);
        }

        [HttpPut("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(Guid id, User updatedUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var success = await _userService.UpdateUser(id, updatedUser);
            if (success == null) return NotFound();
            var mapResult = _mapper.Map<UserDto>(success);
            return Ok(mapResult);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var success = await _userService.DeleteUser(id);
            return StatusCode(StatusCodes.Status200OK,
                    new ResponseRequest
                    {
                        Message = success.Message,
                        Status = "Success"
                    });
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
