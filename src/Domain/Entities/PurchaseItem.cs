
namespace CleanArchTemplate.Domain.Entities;

public class PurchaseItem 
{
    public int PurchaseId { get; private init; }
    public int ProductId { get; private init; }
    public string ProductName { get; private init; }
    public string ProductUnit { get; private init; }
    public decimal ProductPrice { get; private init; }
    public int Quantity { get; private init; }
    public decimal Total => ProductPrice * Quantity;

    private PurchaseItem()
    {
        PurchaseId = 0;
        ProductId = 0;
        ProductName = default!;
        ProductUnit = default!;
        ProductPrice = 0;
        Quantity = 0;
    }

    public PurchaseItem(int productId, string productName, string productUnit, decimal productPrice, int quantity)
    {
        Guard.Against.NegativeOrZero(productId, nameof(productId));
        Guard.Against.NullOrEmpty(productName, nameof(productName));
        Guard.Against.NullOrEmpty(productUnit, nameof(productUnit));
        Guard.Against.NegativeOrZero(productPrice, nameof(productPrice));
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));

        ProductId = productId;
        ProductName = productName;
        ProductUnit = productUnit;
        ProductPrice = productPrice;
        Quantity = quantity;
    }
}
