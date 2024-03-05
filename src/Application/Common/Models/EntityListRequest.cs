namespace CleanArchTemplate.Application.Common.Models;

public class EntityListRequest<T> : IRequest<List<T>>
{
    public string? SortOrder { get; init; }
    public string? OrderBy { get; init; }
}

public class EntityListRequestValidator<T> : AbstractValidator<EntityListRequest<T>>
{
    private readonly HashSet<string> _orderByFields;
    private readonly HashSet<string> _sortOrders = new()
    {
        "asc",
        "desc"
    };

    public EntityListRequestValidator(HashSet<string> orderByFields)
    {
        _orderByFields = orderByFields;
        CreateRules();
    }

    private void CreateRules()
    {
        RuleFor(p => p.OrderBy)
            .Must(o => ValidOrderByField(o))
            .WithMessage(o => $"Invalid OrderBy Field: '{o}'. Allowed values are {string.Join(", ", _orderByFields)}");

        RuleFor(p => p.SortOrder)
            .Must(s => ValidSortOrder(s))
            .WithMessage(s => $"Invalid SortOrder: '{s}'. Please use 'asc' or 'desc'.");
    }

    private bool ValidOrderByField(string? orderBy)
    {
        return string.IsNullOrEmpty(orderBy)? true : _orderByFields.Contains(orderBy);
    }

    private bool ValidSortOrder(string? sortOrder)
    {
        return string.IsNullOrEmpty(sortOrder) ? true : _sortOrders.Contains(sortOrder);
    }
}
