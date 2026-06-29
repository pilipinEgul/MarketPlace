namespace Marketplace.Application.Features.Products.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string Sku { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public bool IsActive { get; set; }
}