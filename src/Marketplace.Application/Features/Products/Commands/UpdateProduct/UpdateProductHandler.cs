using MediatR;
using Marketplace.Application.Features.Products.DTOs;
using Marketplace.Application.Interfaces.Repositories;

namespace Marketplace.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler
    : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto?> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product == null)
            return null;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;
        product.SKU = request.Sku;
        product.CategoryId = request.CategoryId;
        product.IsActive = request.IsActive;

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