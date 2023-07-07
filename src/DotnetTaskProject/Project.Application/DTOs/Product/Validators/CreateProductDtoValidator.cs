using FluentValidation;

namespace Project.Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
	{
		public CreateProductDtoValidator()
		{
			Include(new IProductValidator());
		}
	}
}
