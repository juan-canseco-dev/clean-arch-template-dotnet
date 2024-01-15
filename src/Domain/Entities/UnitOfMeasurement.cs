namespace CleanArchTemplate.Domain.Entities;

public class UnitOfMeasurement : BaseAuditableEntity<int>
{
    public string Name { get; private set; } = default!;

    public void Update(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
    }

    // Required By EF Core
    private UnitOfMeasurement() { }

    public UnitOfMeasurement(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
    }

    public UnitOfMeasurement(int id, string name)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        Guard.Against.NullOrEmpty(name, nameof(name));
        Id = id;
        Name = name;
    }

}
