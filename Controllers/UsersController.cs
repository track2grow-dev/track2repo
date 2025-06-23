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
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
        {
            var user = await _userService.CreateUserAsync(dto);
            return Ok(user);
        }

        // GET: api/user/all
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        // PUT: api/user/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto dto)
        {
            var user = await _userService.UpdateUserAsync(id, dto);
            return Ok(); // placeholder
        }

        // DELETE: api/user/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userService.ArchiveUserAsync(id);
            return Ok(user);
        }

        // RESTORE: api/user/restore/{id}
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreUser(Guid id)
        {
            var user = await _userService.UnarchiveUserAsync(id);
            return Ok(user);
        }
    }
}
