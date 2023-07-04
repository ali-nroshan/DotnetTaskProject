using MediatR;
using Project.Application.DTOs.Product.Validators;
using Project.Application.Features.Product.Requests.Commands;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;

namespace Project.Application.Features.Product.Handlers.Commands
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
	{
		private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var validator = new DeleteProductDtoValidator();
			var validationResult = await validator.ValidateAsync(request.DeleteProductDto);
			if (!validationResult.IsValid)
				throw new BadRequestException();

			var product = await _productRepository.GetProductAsync(request.DeleteProductDto.ManufactureEmail, request.DeleteProductDto.ProductDate);
			if (product == null)
				throw new NotFoundException();
			await _productRepository.DeleteProductAsync(product);
			return Unit.Value;
		}
	}
}
