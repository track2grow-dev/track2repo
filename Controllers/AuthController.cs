using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Track2Grow.API.Data;
using Track2Grow.API.DTOs;
using Track2Grow.API.Services;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Track2Grow.API.Controllers
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
            if (user.PasswordHash != Hash(request.Password))
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        private string Hash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
