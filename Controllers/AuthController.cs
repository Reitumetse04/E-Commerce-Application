using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreAuthAPI.Models;
using OnlineStoreAuthAPI.Services;
using OnlineStoreAuthAPI.Helpers;

namespace OnlineStoreAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            // Validate password strength here (using PasswordValidator)
            if (!PasswordValidator.IsStrongPassword(request.Password))
            {
                return BadRequest("Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.");
            }

            var result = await _authService.RegisterAsync(
                request.Name,
                request.Surname,
                request.Username,
                request.Email,
                request.Password

            );

            if (!result) return BadRequest("User already exists");
            return Ok("Registered successfully");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _authService.AuthenticateAsync(request.Username, request.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetUserProfile()
        {
            var username = User.Identity?.Name;
            return Ok($"You are authenticated as {username}");
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _authService.GetAllUsersAsync();

            var safeUsers = users.Select(u => new
            {
                u.Name,
                u.Surname,
                u.Username,
                u.Email,
                u.Role
            });

            return Ok(safeUsers);
        }

       [Authorize]

        [HttpPost("logout")]
public IActionResult Logout()
{
    if (!User.Identity?.IsAuthenticated ?? true)
    {
        return Unauthorized(new { message = "No user is currently logged in." });
    }

    
    return Ok(new { message = "Successfully logged out." });
}



    }
    
}
