using MediatR;
using Project.Application.DTOs.Product;

namespace Project.Application.Features.Product.Requests.Commands
{
	public class CreateProductCommand : IRequest<int>
	{
        public CreateProductDto CreateProductDto { get; set; }
        public Guid UserId { get; set; }
    }
}
