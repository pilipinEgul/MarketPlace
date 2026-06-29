using MediatR;
using Marketplace.Application.Features.Products.DTOs;
using Marketplace.Application.Interfaces.Repositories;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            StockQuantity = request.StockQuantity,
            SKU = request.Sku,
            CategoryId = request.CategoryId,
            IsActive = request.IsActive
        };

        await _unitOfWork.Products.AddAsync(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

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