﻿namespace Project.Application.DTOs.Product
{
	public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ManufactureEmail { get; set; }

        public string ManufacturePhone { get; set; }

        public DateTime ProductDate { get; set; }

        public bool IsAvailable { get; set; }
    }
}