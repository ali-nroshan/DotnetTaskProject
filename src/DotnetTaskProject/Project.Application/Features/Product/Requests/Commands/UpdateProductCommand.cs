﻿using MediatR;
using Project.Application.DTOs.Product;

namespace Project.Application.Features.Product.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
	{
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
