using MediatR;
using Project.Application.DTOs.Product;

namespace Project.Application.Features.Product.Requests.Queries
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
    }
}
