using CleanArchTemplate.Domain.Entities;

namespace CleanArchTemplate.Application.Categories.Queries.GetCategoryById;

public class CategoryDto
{
    public int Id { get; init; }
    public string? Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
