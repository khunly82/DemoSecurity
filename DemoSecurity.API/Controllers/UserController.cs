using DemoSecurity.API.DTO;
using DemoSecurity.BLL.Services;
using DemoSecurity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace DemoSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(UserDto dto)
        {
            return Ok(userService.Register(new User 
            {
                Email = dto.Email,
                Role = dto.Role,
            }, dto.Password));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto) 
        {
            try
            {
                string token = userService.Login(dto.Email, dto.Password);
                return Ok(new { Token = token });
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
        }
    }
}
