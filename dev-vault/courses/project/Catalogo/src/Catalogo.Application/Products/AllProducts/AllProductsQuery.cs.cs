using Catalogo.Application.Dtos;
using MediatR;

namespace Catalogo.Application.Products.AllProducts;

public sealed class AllProductsQuery : IRequest<IEnumerable<ProductDto>>;