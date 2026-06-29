using Marketplace.Domain.Entities;

namespace Marketplace.Application.Interfaces.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetBySkuAsync(string sku);

    Task<Product?> GetProductWithDetailsAsync(Guid id);

    Task<IReadOnlyList<Product>> GetActiveProductsAsync();
}