using Marketplace.Application.Features.Products.DTOs;
using Marketplace.Application.Features.Products.Queries.GetProducts;
using Marketplace.Application.Interfaces.Repositories;
using MediatR;

namespace Marketplace.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Sku = product.SKU,
            CategoryId = product.CategoryId,
            IsActive = product.IsActive
        };
    }
}