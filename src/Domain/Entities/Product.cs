namespace CleanArchTemplate.Domain.Entities;

public class Product : BaseAuditableEntity<int>
{
    public int SupplierId { get; private set; }
    public int CategoryId { get; private set; }
    public int UnitId { get; private set; }
    public string Name { get; private set; } = default!;
    public decimal PurchasePrice { get; private set; }
    public decimal SalePrice { get; private set; }
    public virtual Supplier Supplier { get; } 
    public virtual Category Category { get; } 
    public virtual UnitOfMeasurement UnitOfMeasurement { get; }
    public virtual Stock Stock { get; }

    public void Update(int supplierId, int categoryId, int unitId, string name, decimal purchasePrice, decimal salePrice)
    {
        Guard.Against.NegativeOrZero(supplierId, nameof(supplierId));
        Guard.Against.NegativeOrZero(categoryId, nameof(categoryId));
        Guard.Against.NegativeOrZero(unitId, nameof(unitId));
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NegativeOrZero(purchasePrice, nameof(purchasePrice));
        Guard.Against.NegativeOrZero(salePrice, nameof(salePrice));
        Guard.Against.SalePriceGreaterThanPurchasePrice(salePrice: salePrice, purchasePrice: purchasePrice);

        SupplierId = supplierId;
        CategoryId = categoryId;
        UnitId = unitId;
        Name = name;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
    }

    // Required By Ef Core 
    private Product()
    {
        Id = 0;
        SupplierId = 0;
        CategoryId = 0;
        UnitId = 0;
        Name = default!;
        PurchasePrice = 0;
        SalePrice = 0;
        Supplier = default!;
        Category = default!;
        UnitOfMeasurement = default!;
        Stock = default!;
    }

    public Product(int supplierId, int categoryId, int unitId, string name, decimal purchasePrice, decimal salePrice)
    {

        Guard.Against.NegativeOrZero(supplierId, nameof(supplierId));
        Guard.Against.NegativeOrZero(categoryId, nameof(categoryId));
        Guard.Against.NegativeOrZero(unitId, nameof(unitId));
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NegativeOrZero(purchasePrice, nameof(purchasePrice));
        Guard.Against.NegativeOrZero(salePrice, nameof(salePrice));
        Guard.Against.SalePriceGreaterThanPurchasePrice(salePrice: salePrice, purchasePrice: purchasePrice);

        SupplierId = supplierId;
        CategoryId = categoryId;
        UnitId = unitId;
        Name = name;
        PurchasePrice = purchasePrice;
        SalePrice = salePrice;
        Stock = new Stock();
        Supplier = default!;
        Category = default!;
        UnitOfMeasurement = default!;
        Stock = new Stock();
    }
}
