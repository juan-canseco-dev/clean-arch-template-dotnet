using CleanArchTemplate.Application.Common.Interfaces;
using CleanArchTemplate.Domain.Entities;

namespace CleanArchTemplate.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name!);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
