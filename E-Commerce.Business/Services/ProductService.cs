﻿using AutoMapper;
using E_Commerce.Business.DTOs.OrderDtos;
using E_Commerce.Business.DTOs.ProductDtos;
using E_Commerce.Business.Interfaces;
using E_Commerce.DataAccess.Respositories;
using E_Commerce.DataAccess.Respositories.Interfaces;
using E_Commerce.DataAccess.UnitOfWork.Interfaces;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateProductDto createProductDto)
        {
            var newProduct = _mapper.Map<Product>(createProductDto);
            await _productRepository.CreateAsync(newProduct);
            await SaveChangesAsync("Product creation failed.");

            return newProduct.Id;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException($"Product with id '{id}' not found.");

            await _productRepository.DeleteByIdAsync(id);
            await SaveChangesAsync("Product deletion failed.");
        }

        public async Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<GetProductDto>>(products);
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id '{id}' not found.");
            }

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task UpdateAsync(int id, UpdateProductDto entity)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new Exception("Product not found");

            _mapper.Map(entity, product);
            await _productRepository.UpdateAsync(product);
            await SaveChangesAsync("Failed to update product.");
        }

        // Private helper method to handle save changes with consistent error handling
        private async Task SaveChangesAsync(string errorMessage)
        {
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{errorMessage}. Details: {ex.Message}");
            }
        }
    }
}
