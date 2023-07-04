using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
