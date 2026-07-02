using MediatR;
using Marketplace.Application.Features.Categories.DTOs;

namespace Marketplace.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public string Name { get; set; } = string.Empty;
}