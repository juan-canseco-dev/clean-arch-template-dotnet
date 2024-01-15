namespace Ardalis.GuardClauses;


public static class ProductGuards
{
    public static void SalePriceGreaterThanPurchasePrice(this IGuardClause guardClause, decimal salePrice, decimal purchasePrice)
    {
        if (salePrice <= purchasePrice)
        {
            throw new ArgumentException("Sale Price Must Be Greater Than Purchase Price.");
        }
    }

    public static void InvalidStockOperation(this IGuardClause guardClause, Stock stock, int removeQuantity)
    {
        if (removeQuantity > stock.Quantity)
        {
            throw new InvalidStockOperationException(stock, removeQuantity);
        }
    }

}
