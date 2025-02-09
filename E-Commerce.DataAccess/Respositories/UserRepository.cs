﻿using E_Commerce.DataAccess.Context;
using E_Commerce.DataAccess.Respositories.Interfaces;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DataAccess.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceContext _context;

        public UserRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User entity)
        {
            // Add to the database
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            // Find the user to be deleted
            var user = await _context.Users.FindAsync(id);

            // Remove user
            _context.Users.Remove(user!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync(); // Get all users in a list
        }

        public async Task<User> GetByIdAsync(string id)
        {
            // Find requested user
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            return user!;
        }

        public async Task UpdateAsync(User entity)
        {
            // Update user
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
