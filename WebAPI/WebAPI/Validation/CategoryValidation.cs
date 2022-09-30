namespace WebAPI.Validation
{
    public class CategoryValidation:AbstractValidator<CategoryCreateDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(Messages.CategoryNameCanNotNull)
                .NotEmpty()
                .WithMessage(Messages.CategoryNameCanNotEmpty)
                .MaximumLength(25)
                .WithMessage(Messages.CategoryNameMaxValueMustBeTwentyFive)
                .MinimumLength(1)
                .WithMessage(Messages.CategoryNameMinValueMustBeOne);

        }
    }
}
