namespace CleanArchTemplate.Application.Common.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository Categories { get; }
    IUnitOfMeasurementRepository Units { get; }
    ISupplierRepository Suppliers { get; }
    IProductRepository Products { get; }
    IPurchaseRepository Purchases { get; }
    ICustomerRepository Customers { get; }
    IOrderRepository Orders { get; }
    Task CommitAsync(CancellationToken cancellationToken = default);
}
