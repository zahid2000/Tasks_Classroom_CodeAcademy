namespace Code.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName is required")
                                        .MaximumLength(200).WithMessage("ProductName  must not exceed 200 characters");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");
            
        }
    }
}
