using MediatR;
using Project.Application.DTOs.Product;

namespace Project.Application.Features.Product.Requests.Queries
{
    public class GetProductByUserRequest : IRequest<List<ProductDto>>
    {
        public Guid UserId { get; set; }
    }
}
