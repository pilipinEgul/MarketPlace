using MediatR;
using Marketplace.Application.Features.Products.DTOs;

namespace Marketplace.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public Guid Id { get; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}