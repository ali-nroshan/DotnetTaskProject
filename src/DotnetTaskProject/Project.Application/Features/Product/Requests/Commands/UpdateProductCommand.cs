using MediatR;
using Project.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Product.Requests.Commands
{
	public class UpdateProductCommand : IRequest<Unit>
	{
        public int ProductId { get; set; }
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
