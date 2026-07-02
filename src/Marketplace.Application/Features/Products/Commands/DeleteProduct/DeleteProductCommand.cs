using MediatR;

namespace Marketplace.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }
}