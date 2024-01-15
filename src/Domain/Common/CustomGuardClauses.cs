namespace Ardalis.GuardClauses;

public static class CustomGuardClauses
{
    public static void SalePriceGreaterThanPurchasePrice(this IGuardClause guardClause, decimal salePrice, decimal purchasePrice)
    {
        if (salePrice <= purchasePrice)
        {
            throw new ArgumentException("Sale Price Must Be Greater Than Purchase Price.");
        }
    }
}
