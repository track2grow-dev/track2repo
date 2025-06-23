using Track2GrowProject.API.DTOs;
using Track2GrowProject.API.Models.Entities;

namespace Track2GrowProject.API.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDto dto);
        Task<User> UpdateUserAsync(Guid id, UserDto dto);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> ArchiveUserAsync(Guid id);
        Task<bool> UnarchiveUserAsync(Guid id);
        Task<User> GetUserAsync(Guid id);

    }
}
