using Marketplace.Application.Interfaces.Repositories;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories;

public class ProductRepository
    : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(MarketplaceDbContext context)
        : base(context)
    {
    }

    public async Task<Product?> GetBySkuAsync(string sku)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.SKU == sku);
    }

    public async Task<Product?> GetProductWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Product>> GetActiveProductsAsync()
    {
        return await _dbSet
            .Where(p => p.IsActive)
            .ToListAsync();
    }
}