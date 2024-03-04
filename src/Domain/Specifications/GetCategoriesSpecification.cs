

namespace CleanArchTemplate.Domain.Specifications;
public class GetCategoriesSpecification : BaseSpecifcation<Category>
{
    private static Dictionary<string, Func<IQueryable<Category>, IOrderedQueryable<Category>>> OrderByDictionary => new()
    {
        {"id.asc", q => q.OrderBy(q => q.Id)},
        {"id.desc", q => q.OrderByDescending(q => q.Id) },
        {"name.asc", q => q.OrderBy(q => q.Name) },
        {"name.desc", q => q.OrderByDescending(q => q.Name)}
    };

    private static Dictionary<string, bool> SortOrderDictionary => new()
    {
        {"asc", true },
        {"desc", false }
    };

    private static Expression<Func<Category, bool>> BuildCriteria(string orderBy, string sortOrder, string Name)
    {

        return null;
    }

    public GetCategoriesSpecification(string orderBy, string sortOrder, string name) :
        base(BuildCriteria(orderBy, sortOrder, name))
    {
        
    }
}
