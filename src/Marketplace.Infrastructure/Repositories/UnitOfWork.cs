using Marketplace.Application.Interfaces.Repositories;
using Marketplace.Infrastructure.Data;

namespace Marketplace.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MarketplaceDbContext _context;

    public IProductRepository Products { get; }

    public ICategoryRepository Categories { get; }

    public UnitOfWork(MarketplaceDbContext context)
    {
        _context = context;

        Products = new ProductRepository(context);
        Categories = new CategoryRepository(context);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}