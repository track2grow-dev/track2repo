using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
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

        public async Task<User> CreateUserAsync(UserDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower().Trim() == dto.Email.ToLower().Trim()))
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

        public async Task<User> UpdateUserAsync(Guid id, UserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PasswordHash = SecurityHelper.Hash(dto.Password);
            user.Role = dto.Role;
            user.ManagerId = dto.ManagerId;

            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Where(u => !u.IsArchived).ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> ArchiveUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            if (!user.IsArchived)
            {
                user.IsArchived = true;
                await _context.SaveChangesAsync();
            }

            return true;
        }


        public async Task<bool> UnarchiveUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            if (!user.IsArchived)
            {
                user.IsArchived = false;
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }

}

