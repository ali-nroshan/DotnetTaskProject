using FluentValidation;

namespace Project.Application.DTOs.Product.Validators
{
    public class DeleteProductDtoValidator : AbstractValidator<DeleteProductDto>
	{
		public DeleteProductDtoValidator()
		{
			RuleFor(p => p.ManufactureEmail).NotEmpty().EmailAddress()
				.MaximumLength(100);

			RuleFor(p => p.ProductDate).NotNull();
		}
	}
}
