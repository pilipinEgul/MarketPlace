using Marketplace.Application.Features.Products.Commands.CreateProduct;
using Marketplace.Application.Features.Products.Queries.GetProductById;
using Marketplace.Application.Features.Products.Queries.GetProducts;
using Marketplace.Application.Features.Products.Commands.UpdateProduct;
using Marketplace.Application.Features.Products.Commands.DeleteProduct;

using MediatR;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetProductsQuery());

        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("Route ID and body ID must match.");

        var product = await _mediator.Send(command);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));

        if (!result)
            return NotFound();

        return NoContent();
    }
}