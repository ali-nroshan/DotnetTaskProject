using AutoMapper;
using Project.Application.DTOs.Product;
using Project.Domain.Entities;

namespace Project.Application.Profiles
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
		}
	}
}