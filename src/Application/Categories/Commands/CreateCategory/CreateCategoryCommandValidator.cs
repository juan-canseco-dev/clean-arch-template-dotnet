namespace CleanArchTemplate.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator() 
    {
        RuleFor(c => c.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(50);
    }
}
