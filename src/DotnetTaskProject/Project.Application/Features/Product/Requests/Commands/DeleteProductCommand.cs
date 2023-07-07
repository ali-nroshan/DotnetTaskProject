using MediatR;
using Project.Application.DTOs.Product;

namespace Project.Application.Features.Product.Requests.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
	{
        public Guid UserId { get; set; }
        public DeleteProductDto DeleteProductDto { get; set; }
    }
}
