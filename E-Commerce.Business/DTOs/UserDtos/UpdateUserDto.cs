﻿using E_Commerce.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Business.DTOs.UserDtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be minimum of 2, maximum of 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be minimum of 2, maximum of 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail adress.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        //[Required]
        //[MinLength(8)]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters, contain letters and numbers.")]
        //public string Password { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }
}
