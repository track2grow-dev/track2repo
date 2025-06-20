using Microsoft.EntityFrameworkCore;
using Track2GrowProject.Interfaces;
using Track2GrowProject.API.Data;
using Track2GrowProject.API.DTOs;
using Track2GrowProject.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Track2GrowProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Track2GrowDbContext _context;
        private readonly IJwtTokenService _jwtService;

        public AuthController(Track2GrowDbContext context, IJwtTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return Unauthorized("Invalid credentials");

            // Use hashed passwords in real app — use plain for now
            if (user.PasswordHash != SecurityHelper.Hash(request.Password))
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
