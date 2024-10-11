using MediatR;
using Microsoft.AspNetCore.Mvc;
using PilotPhase.Application.Commands.ProductCommand;
using PilotPhase.Application.Queries.ProductQuery;
using PilotPhase.DTO.Product;
using PilotPhase.Shared.Messages;

namespace PilotPhase.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getproducts")]       
        public async Task<ActionResult<List<GetProductDTO>>> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost("product")]      
        public async Task<ActionResult<string>> CreateProduct([FromBody] ProductDTO  productDTO)
        {
            var productId = await _mediator.Send(new CreateProductCommand(productDTO));
            return Ok(new { response = Responses.RecordCreated });            
        }             
       

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProduct( [FromBody] UpdateProductDTO productDto)
        {
            var result = await _mediator.Send(new UpdateProductCommand( productDto));

            if (!result)
            {
                return NotFound();
            }

            return NoContent(); // Success
        }


        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            if (!result)
            {
                return NotFound();
            }

            return NoContent(); // Success
        }

        //[HttpDelete("DeleteProduct/{id}")]
        //public async Task<ActionResult<bool>> DeleteProduct(string id)
        //{
        //    var result = await _mediator.Send(new DeleteProductCommand(id));
        //    if (!result)
        //    {
        //        return NotFound("Product not found");
        //    }
        //    return Ok(result);
        //}
    }
}