namespace CleanArchTemplate.Domain.Entities;

public class OrderItem
{
    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public string ProductName { get; private set; }
    public string ProductUnit { get; private set; }
    public decimal ProductPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Total => ProductPrice * Quantity;
    private OrderItem()
    {
        OrderId = 0;
        ProductId = 0;
        ProductName = default!;
        ProductUnit = default!;
        ProductPrice = 0;
        Quantity = 0;
    }

    public OrderItem(int productId, string productName, string productUnit, decimal productPrice, int quantity)
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
