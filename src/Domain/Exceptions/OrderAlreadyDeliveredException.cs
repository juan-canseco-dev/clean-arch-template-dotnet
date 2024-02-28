namespace CleanArchTemplate.Domain.Exceptions;

public class OrderAlreadyDeliveredException : DomainException
{
    public OrderAlreadyDeliveredException(Order order) : base(BuildMessage(order))
    {
    }

    private static string BuildMessage(Order order)
    {
        return $"The Order with the Id : {order.Id} is alredy delivered.";
    }
}
