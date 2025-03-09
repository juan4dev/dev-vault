using Catalogo.Api.Dtos;
using Catalogo.Application.Dtos;
using Catalogo.Application.Products.AllProducts;
using Catalogo.Application.Products.CreateProduct;
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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new AllProductsQuery();
        var products = await _sender.Send(query, cancellationToken);

        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductRequest productRequest)
    {
        var command = new CreateProductCommand(
            productRequest.Name,
            productRequest.Description,
            productRequest.Price,
            productRequest.CategoryId
        );
        var createdProduct = await _sender.Send(command);
        return Ok(createdProduct);
    }
}