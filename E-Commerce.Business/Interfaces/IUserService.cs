﻿using E_Commerce.Business.DTOs.UserDtos;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IUserService 
    {
        Task<int> CreateUserAsync(CreateUserDto createUserDto);
        Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task DeleteUserByIdAsync(int id);
    }
}
