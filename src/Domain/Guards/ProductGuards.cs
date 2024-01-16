namespace Ardalis.GuardClauses;


public static class ProductGuards
{
    public static void NegativeProfit(this IGuardClause guardClause, decimal salePrice, decimal purchasePrice)
    {
        if (salePrice <= purchasePrice)
        {
            throw new NegativeProfitException();
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
