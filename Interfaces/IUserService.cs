using Track2GrowProject.API.DTOs;
using Track2GrowProject.API.Models.Entities;

namespace Track2GrowProject.API.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto dto);
        Task<List<User>> GetAllUsersAsync();
    }
}
