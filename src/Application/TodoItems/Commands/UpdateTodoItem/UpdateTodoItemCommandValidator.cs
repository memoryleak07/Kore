namespace Kore.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateProductItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateProductItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
