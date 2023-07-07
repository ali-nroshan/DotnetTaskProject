using AutoMapper;
using MediatR;
using Project.Application.DTOs.Product;
using Project.Application.Features.Product.Requests.Queries;
using Project.Application.Contracts.Persistence;

namespace Project.Application.Features.Product.Handlers.Queries
{
    public class GetProductByUserRequestHandler : IRequestHandler<GetProductByUserRequest, List<ProductDto>>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

        public GetProductByUserRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
			_mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductByUserRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetProductsByUserIdAsync(request.UserId);
			return _mapper.Map<List<ProductDto>>(products);
		}
	}
}
