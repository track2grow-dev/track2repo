using Microsoft.AspNetCore.Authorization;
using Track2GrowProject.API.Interfaces;
using Track2GrowProject.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Track2Grow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/user/create
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = await _userService.CreateUserAsync(dto);
            return Ok(user);
        }

        // GET: api/user/all
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            // You can implement GetUserByIdAsync() in service if needed
            return Ok(); // placeholder
        }

        // PUT: api/user/update/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] CreateUserDto dto)
        {
            // Call _userService.UpdateUserAsync(id, dto);
            return Ok(); // placeholder
        }

        // DELETE: api/user/delete/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            // Call _userService.DeleteUserAsync(id);
            return Ok(); // placeholder
        }
    }
}
