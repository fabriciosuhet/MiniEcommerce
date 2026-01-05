using Auth.API.DTOS;
using Auth.API.Entities;
using Auth.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
           var userId = await _userService.CreateUserAsync(request.Email, request.Senha);
           return CreatedAtAction(nameof(ValidateUser), new { id = userId }, new { UserId = userId});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            var userId = await _userService.AuthenticateAsync(request.Email, request.Senha);
            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok(new { UserId = userId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ValidateUser(Guid id)
        {
            var exists = await _userService.UserExistsAsync(id);
            if (!exists)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
