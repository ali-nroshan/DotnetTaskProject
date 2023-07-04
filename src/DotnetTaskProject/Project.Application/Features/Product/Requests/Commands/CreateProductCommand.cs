﻿using MediatR;
using Project.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Product.Requests.Commands
{
	public class CreateProductCommand : IRequest<int>
	{
        public CreateProductDto CreateProductDto { get; set; }
    }
}
