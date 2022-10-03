using Code.Application.Common.Interfaces;
using FluentValidation;

namespace Code.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;
           
        }

    }
}
