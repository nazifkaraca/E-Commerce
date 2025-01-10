﻿using E_Commerce.DataAccess.Context;
using E_Commerce.DataAccess.Respositories.Interfaces;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Respositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;

        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product entity)
        {
            // Throw null if entity is null
            ArgumentNullException.ThrowIfNull(entity);

            // Add to the database
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            // Find the order to be deleted
            var product = await _context.Products.FindAsync(id);

            // If not found, throw and exception
            ArgumentNullException.ThrowIfNull(product);

            // Remove order
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // Get all orders in a list 
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            // Find requested order
            var product = await _context.Products.FindAsync(id);

            // Throw an exception if not found
            ArgumentNullException.ThrowIfNull(product);

            return product;
        }

        public async Task UpdateAsync(Product entity)
        {
            // Throw an exception if not found
            ArgumentNullException.ThrowIfNull(entity);

            // Update order
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
