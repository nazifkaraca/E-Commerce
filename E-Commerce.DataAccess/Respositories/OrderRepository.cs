﻿using E_Commerce.DataAccess.Context;
using E_Commerce.DataAccess.Respositories.Interfaces;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DataAccess.Respositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceContext _context;

        public OrderRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order entity)
        {
            // Add to the database
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            // Find the order to be deleted
            var order = await _context.Orders.FindAsync(id);

            // Remove order
            _context.Orders.Remove(order!);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync(); // Get all orders in a list
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            // Find requested order
            var order = await _context.Orders
                        .Include(o => o.OrderProducts) // İlişkili ürünleri yükle
                        .FirstOrDefaultAsync(o => o.Id == id);

            return order!;
        }

        public async Task UpdateAsync(Order entity)
        {
            // Update order
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
