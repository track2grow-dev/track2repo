using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Track2GrowProject.API.Data;
using Track2GrowProject.API.DTOs;
using Track2GrowProject.API.Interfaces;
using Track2GrowProject.API.Models.Entities;
using Track2GrowProject.Helpers;


namespace Track2GrowProject.API.Services
{
    public class UserService : IUserService
    {
        private readonly Track2GrowDbContext _context;

        public UserService(Track2GrowDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = SecurityHelper.Hash(dto.Password),
                Role = dto.Role,
                ManagerId = dto.ManagerId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Where(u => !u.IsArchived).ToListAsync();
        }
    }

}

