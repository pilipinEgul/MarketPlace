using MediatR;
using Marketplace.Application.Features.Products.DTOs;

namespace Marketplace.Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}