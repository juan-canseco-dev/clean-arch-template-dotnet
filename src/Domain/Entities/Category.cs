namespace CleanArchTemplate.Domain.Entities;

public class Category : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;

    public void Update(string name)
    {
        Guard.Against.NullOrEmpty(Guard.Against.NullOrEmpty(name, nameof(name)));
        Name = name;
    }

    private Category() { }

    public Category(int id, string name)  
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        Guard.Against.NullOrEmpty(Guard.Against.NullOrEmpty(name, nameof(name)));
        Id = id;
        Name = name;
    }

    public Category(string name) 
    {
        Guard.Against.NullOrEmpty(Guard.Against.NullOrEmpty(name, nameof(name)));
        Name = name;
    }
}
