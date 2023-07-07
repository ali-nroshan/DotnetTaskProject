using AutoMapper;
using MediatR;
using Project.Application.DTOs.Product.Validators;
using Project.Application.Features.Product.Requests.Commands;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;

namespace Project.Application.Features.Product.Handlers.Commands
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit> //we can remove unit from output result
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
			_productRepository = productRepository;
			_mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateProductDtoValidator();
			var validationResult = await validator.ValidateAsync(request.UpdateProductDto);
			if (!validationResult.IsValid)
				throw new BadRequestException();

			var product = await _productRepository.GetProductByIdAsync(request.ProductId);
			if (product == null)
				throw new NotFoundException();

			if (product.UserId != request.UserId)
				throw new UnauthorizedException();

			_mapper.Map(request.UpdateProductDto, product);
			await _productRepository.UpdateProductAsync(product);
			return Unit.Value;
		}
	}
}
