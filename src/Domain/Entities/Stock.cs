namespace CleanArchTemplate.Domain.Entities;

public class Stock : BaseAuditableEntity<int>
{
    public int ProductId { get; }
    public int Quantity { get; private set; }

    public void AddStock(int quantity)
    {
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));

        var newQuantity = Quantity + quantity;
        Quantity = newQuantity;
    }

    public void RemoveStock(int quantity)
    {
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));
        Guard.Against.InvalidStockOperation(this, quantity);
        var newQuantity = Quantity - quantity;
        Quantity = newQuantity;
    }

    private Stock()
    {
        ProductId = 0;
        Quantity = 0;
    }

    public Stock(int productId = 0, int quantity = 0)
    {
        Guard.Against.Negative(productId, nameof(productId));
        Guard.Against.Negative(quantity, nameof(quantity));

        ProductId = productId;
        Quantity = quantity;
    }

}
