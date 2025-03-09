using Catalogo.Application.Dtos;
using Catalogo.Application.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers.Products;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("code/{code}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<ProductDto>> GetByCode([FromRoute] string code, CancellationToken cancellationToken)
    {
        try
        {
            var query = new SearchProductQuery { Code = code };
            var product = await _sender.Send(query, cancellationToken);

            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Product not found");
        }
    }
}