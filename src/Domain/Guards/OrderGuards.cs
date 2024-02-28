namespace CleanArchTemplate.Domain.Guards;

public static class OrderGuards
{
    public static void DeliverTwice(this IGuardClause guardClause, Order order)
    {
        if (order.Delivered)
        {
            throw new OrderAlreadyDeliveredException(order);
        }
    }
}
