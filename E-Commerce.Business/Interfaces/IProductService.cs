﻿using E_Commerce.Business.DTOs.ProductDtos;

namespace E_Commerce.Business.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<GetProductDto>> GetAllAsync(); // Gets all data.
        Task<GetProductDto> GetByIdAsync(int id);      // Gets data by ID.
        Task CreateAsync(CreateProductDto createProductDto);        // Create a new resource.
        Task UpdateAsync(int id, UpdateProductDto updateProductDto);        // Updates existing data.
        Task DeleteByIdAsync(int id);      // Deletes data by ID.
    }
}
