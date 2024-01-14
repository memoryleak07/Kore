using Kore.Application.ProductItems.Commands;

namespace Kore.Application.ProductItems.Validators;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductItemCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
