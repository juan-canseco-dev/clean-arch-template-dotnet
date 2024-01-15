
namespace CleanArchTemplate.Domain.Exceptions;

public class InvalidStockOperationException : DomainException
{
    public InvalidStockOperationException(Stock stock, int removeQuantity) : base(BuildErrorMessage(stock, removeQuantity)) {}

    static string BuildErrorMessage(Stock stock, int removeQuantity)
    {
        return $"Invalid stock operation: Cannot remove {removeQuantity} units from inventory. Current stock quantity for ProductId {stock.ProductId}: {stock.Quantity}.";
    }
}
