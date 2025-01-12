﻿using Microsoft.AspNetCore.Mvc;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.DTOs.UserDtos;
using E_Commerce.Business.Types;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(new ServiceMessage<IEnumerable<GetUserDto>>
            {
                IsSucceed = true,
                Count = users.Count(),
                Data = users
            });
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceMessage<GetUserDto>>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return Ok(new ServiceMessage<GetUserDto>
            {
                IsSucceed = true,
                Data = user
            });
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto newUser)
        {
            await _userService.CreateUserAsync(newUser);

            return Ok(new ServiceMessage<CreateUserDto>
            {
                IsSucceed = true,
                Message = $"Product successfully created.",
                Data = newUser
            });
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto newUser)
        {
            await _userService.UpdateUserAsync(id, newUser);

            return Ok(new ServiceMessage
            {
                IsSucceed = true,
                Message = $"User with '{id}' id successfully updated."
            });
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            await _userService.DeleteUserByIdAsync(id);

            return Ok(new ServiceMessage
            {
                IsSucceed = true,
                Message = $"User with '{id}' id successfully deleted."
            });
        }
    }
}
