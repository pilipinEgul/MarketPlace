using Marketplace.Application.Interfaces.Repositories;
using Marketplace.Infrastructure.Data;

namespace Marketplace.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MarketplaceDbContext _context;

    public IProductRepository Products { get; }

    public UnitOfWork(
     MarketplaceDbContext context,
     IProductRepository productRepository)
    {
        _context = context;
        Products = productRepository;
    }
    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}