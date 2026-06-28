using Marketplace.Domain.Common;

namespace Marketplace.Domain.Entities;

public class ProductImage : BaseEntity
{
    public string ImageUrl { get; set; } = string.Empty;

    public bool IsPrimary { get; set; }

    public int DisplayOrder { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;
}