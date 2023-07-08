using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.DTOs.Product;
using Project.Application.Features.Product.Requests.Commands;
using Project.Application.Features.Product.Requests.Queries;

namespace Project.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ProductController(IMediator mediator)
		{
			_mediator = mediator;
		}

		private Guid _userId
		{
			get
			{
				return Guid.Parse(User.FindFirst("userid")!.Value);
			}
		}


		// GET: api/<ProductController>
		[HttpGet]
		public async Task<ActionResult<List<ProductDto>>> GetProducts()
		{
			var products = await _mediator.Send(new GetProductListRequest());
			return Ok(products);
		}

		// GET api/<ProductController>/UserProducts/5
		[HttpGet("UserProducts/{userId}")]
		public async Task<ActionResult<List<ProductDto>>> GetUserProducts(Guid userId)
		{
			var request = new GetProductByUserRequest { UserId = userId };
			var respone = await _mediator.Send(request);
			return Ok(respone);
		}

		// POST api/<ProductController>
		[Authorize]
		[HttpPost]
		public async Task<ActionResult<int>> NewProduct([FromBody] CreateProductDto productDto)
		{
			var command = new CreateProductCommand { UserId = _userId, CreateProductDto = productDto };
			int response = await _mediator.Send(command);
			return Ok(response);
		}

		// PUT api/<ProductController>/5
		[Authorize]
		[HttpPut("{productId}")]
		public async Task<ActionResult> EditProduct(int productId, [FromBody] UpdateProductDto updateProductDto)
		{
			var command = new UpdateProductCommand { UserId = _userId, ProductId = productId, UpdateProductDto = updateProductDto };
			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<ProductController>/5
		[Authorize]
		[HttpDelete]
		public async Task<ActionResult> DeleteProduct([FromBody] DeleteProductDto deleteProductDto)
		{
			var command = new DeleteProductCommand { UserId = _userId, DeleteProductDto = deleteProductDto };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
