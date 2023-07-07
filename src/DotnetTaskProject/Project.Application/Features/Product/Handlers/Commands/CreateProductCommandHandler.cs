using AutoMapper;
using MediatR;
using Project.Application.DTOs.Product.Validators;
using Project.Application.Features.Product.Requests.Commands;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;

namespace Project.Application.Features.Product.Handlers.Commands
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
	{
		private readonly IProductRepository _productRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		public CreateProductCommandHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_userRepository = userRepository;
			_mapper = mapper;
		}
		public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateProductDtoValidator();
			var validationResult = await validator.ValidateAsync(request.CreateProductDto);
			if (!validationResult.IsValid)
				throw new BadRequestException();

			if (!await _userRepository.UserIdExistAsync(request.UserId))
				throw new UnauthorizedException();

			if (await _productRepository.ProductExistAsync(request.CreateProductDto.ManufactureEmail, request.CreateProductDto.ProductDate))
				throw new BadRequestException();

			var newProduct = _mapper.Map<Domain.Entities.Product>(request.CreateProductDto);
			newProduct.UserId = request.UserId;
			await _productRepository.CreateProductAsync(newProduct);
			return newProduct.ProductId;
		}
	}
}
