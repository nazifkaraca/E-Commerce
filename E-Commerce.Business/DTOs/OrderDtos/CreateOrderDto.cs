﻿using E_Commerce.Business.DTOs.OrderProductDtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Business.DTOs.OrderDtos
{
    public class CreateOrderDto
    {
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date time.")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be at least 0.01.")]
        [DefaultValue(0.01)]
        public decimal TotalAmount { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}
