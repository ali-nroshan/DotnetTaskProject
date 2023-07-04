using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs.Product.Validators
{
	public class IProductValidator : AbstractValidator<IProductDto>
	{
        public IProductValidator()
        {
			RuleFor(p => p.ProductName).NotEmpty()
			.MinimumLength(1).MaximumLength(100);

			RuleFor(p => p.ManufactureEmail).NotEmpty()
				.EmailAddress().MaximumLength(100);

			RuleFor(p => p.ManufacturePhone).NotEmpty();

			RuleFor(p => p.ProductDate).NotNull();

		}
	}
}
