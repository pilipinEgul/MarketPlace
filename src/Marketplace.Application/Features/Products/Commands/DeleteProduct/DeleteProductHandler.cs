using MediatR;
using Marketplace.Application.Interfaces.Repositories;

namespace Marketplace.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler
    : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product == null)
            return false;

        _unitOfWork.Products.Remove(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}