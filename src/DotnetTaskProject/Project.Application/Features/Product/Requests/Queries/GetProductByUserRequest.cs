using MediatR;
using Project.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Product.Requests.Queries
{
    public class GetProductByUserRequest : IRequest<List<ProductDto>>
    {
        public int UserId { get; set; }
    }
}
