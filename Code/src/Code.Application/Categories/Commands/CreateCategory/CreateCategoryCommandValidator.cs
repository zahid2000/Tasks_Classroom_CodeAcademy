using Code.Application.Common.Interfaces;
using FluentValidation;

namespace Code.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(c => c.CategoryName)
            .NotEmpty().WithMessage("CategoryName is required")
            .MaximumLength(200).WithMessage("CategoryzName must not exceed 200 characters")
            .MustAsync(BeUniqName).WithMessage("The specific Category Name already exists");
    }
    public async Task<bool> BeUniqName(string categoryName,CancellationToken cancellationToken)
    {
        return await _context.Categories.AllAsync(x => x.CategoryName != categoryName, cancellationToken);
    }
}