using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.AllProducts;

internal sealed class AllProductsQueryHandler : IRequestHandler<AllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public AllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<ProductDto>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);
        return products.ToDtoList();
    }
}
