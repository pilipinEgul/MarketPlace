using MediatR;
using Marketplace.Application.Features.Products.DTOs;
using Marketplace.Application.Interfaces.Repositories;

namespace Marketplace.Application.Features.Products.Queries.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            Sku = p.SKU,
            CategoryId = p.CategoryId,
            IsActive = p.IsActive
        });
    }
}