using Code.Application.Common.Interfaces;
using FluentValidation;

namespace Code.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(c => c.Id).NotEmpty().WithMessage("Category id is required");
        RuleFor(c => c.CategoryName)
            .NotEmpty().WithMessage("CategoryName is required")
            .MaximumLength(200).WithMessage("CategoryName must not exceed 200 characters")
            .MustAsync(BeUniqName).WithMessage("The specific Category Name already exists");
    }
    public async Task<bool> BeUniqName(UpdateCategoryCommand model, string categoryName, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(x => x.Id != model.Id)
            .AllAsync(x => x.CategoryName != categoryName, cancellationToken);
    }
}