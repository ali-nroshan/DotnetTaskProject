using FluentValidation;

namespace Project.Application.DTOs.Product.Validators
{
	public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
	{
        public UpdateProductDtoValidator()
        {
            Include(new IProductValidator());
        }
    }
}
