namespace CleanArchTemplate.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(50);
    }
}
