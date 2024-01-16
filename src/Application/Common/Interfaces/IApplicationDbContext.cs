using CleanArchTemplate.Domain.Entities;

namespace CleanArchTemplate.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Supplier> Suppliers { get; }
    DbSet<Category> Categories { get; }
    DbSet<UnitOfMeasurement> UnitOfMeasurements { get; }
    DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
