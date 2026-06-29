using MediatR;
using Marketplace.Application.Features.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateProductCommand command)
    {
        var product = await _mediator.Send(command);

        return Ok(product);
    }
}