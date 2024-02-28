namespace CleanArchTemplate.Domain.Guards;

public static class PurchaseGuards
{
    public static void ReceiveTwice(this IGuardClause guardClause, Purchase purchase)
    {
        if (purchase.Arrived)
        {
            throw new PurchaseAlreadyReceivedException(purchase);
        }
    }
}
