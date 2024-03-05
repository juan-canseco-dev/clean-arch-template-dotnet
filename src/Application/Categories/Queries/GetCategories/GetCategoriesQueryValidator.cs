using CleanArchTemplate.Application.Common.Models;

namespace CleanArchTemplate.Application.Categories.Queries.GetCategories;

public class GetCategoriesQueryValidator : EntityListRequestValidator<GetCategoriesQuery>
{
    public GetCategoriesQueryValidator() : base(new() { "id", "name"})
    {

    }
}
