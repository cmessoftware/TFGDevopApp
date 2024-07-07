﻿using Microsoft.EntityFrameworkCore;
using TFGDevopsApp1.Data;
using TFGDevopsApp1.Interfaces;

namespace TFGDevopsApp1.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> RegisterUser(string email, string password)
        {
            try
            {
                var user = new ApplicationUser
                {
                    Email = email,
                    UserName = email
                };
                //user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                //await _context.Users.AddAsync(user);
                //await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser != null)
            {
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string userId)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> ValidateLog(string userName, string password)
        {

            var response = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());

            return Task.FromResult(response != null);
        }
        public async Task<bool> ValidateUser(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());

            //var response = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            return await Task.FromResult(false);
        }
    }
}