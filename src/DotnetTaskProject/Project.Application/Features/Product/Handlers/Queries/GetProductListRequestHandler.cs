using AutoMapper;
using MediatR;
using Project.Application.DTOs.Product;
using Project.Application.Features.Product.Requests.Queries;
using Project.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Product.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}


        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetProductsAsync();
			return _mapper.Map<List<ProductDto>>(products);
		}
	}
}
