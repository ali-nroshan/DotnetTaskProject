using FluentValidation;
using Project.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs.Product.Validators
{
	public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
	{
		private readonly IUserRepository _userRepository;
		public CreateProductDtoValidator(IUserRepository userRepository)
		{
			_userRepository = userRepository;
			Include(new IProductValidator());

			RuleFor(p => p.UserId).GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					return !await _userRepository.UserIdExistAsync(id);
				});
		}
	}
}
