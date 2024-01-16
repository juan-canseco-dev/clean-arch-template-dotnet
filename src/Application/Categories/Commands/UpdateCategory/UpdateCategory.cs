
using CleanArchTemplate.Application.Common.Interfaces;

namespace CleanArchTemplate.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Update(request.Name!);

        await _context.SaveChangesAsync(cancellationToken);
    }
}