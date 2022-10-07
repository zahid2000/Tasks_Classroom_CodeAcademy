using FluentValidation;
using Microservices.Category.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Category.Validations
{
    public class CategoryValidator:AbstractValidator<DE.Category>
    {
        private readonly ICategoryRepository _categoryRepository;


        public CategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("CategoryName" + Messages.CannotBeNullOrEmpty)
                .MaximumLength(200).WithMessage(Messages.CategoryNameMaxLengthValidator)
                .MinimumLength(2).WithMessage(Messages.CategoryNameMinLengthValidator)
                .MustAsync(BeUniqName).WithMessage(Messages.CategoryNameExists);
        }
        public async Task<bool> BeUniqName(DE.Category category,string categoryName,CancellationToken cancellationToken)
        {
            var entity = await _categoryRepository.GetAsync(c => c.CategoryName == category.CategoryName,cancellationToken);
            if (entity==null)
            {
                return false;
            }
            return true;
        }
    }
}
