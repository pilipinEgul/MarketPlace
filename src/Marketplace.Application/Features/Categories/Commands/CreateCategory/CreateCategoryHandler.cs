using MediatR;
using Marketplace.Application.Features.Categories.DTOs;
using Marketplace.Application.Interfaces.Repositories;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryHandler
    : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryDto> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name
        };

        await _unitOfWork.Categories.AddAsync(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}