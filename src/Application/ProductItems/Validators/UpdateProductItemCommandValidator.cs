using Kore.Application.ProductItems.Commands;

namespace Kore.Application.ProductItems.Validators;

public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductItemCommand>
{
    public UpdateProductCategoryCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
