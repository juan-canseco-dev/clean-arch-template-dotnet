namespace CleanArchTemplate.Domain.Exceptions;

public class PurchaseAlreadyReceivedException : DomainException
{
    public PurchaseAlreadyReceivedException(Purchase purchase) : base(BuildMessage(purchase))
    {
    }   

    private static string BuildMessage(Purchase purchase)
    {
        return $"The Purchase with the Id : {purchase.Id} is alredy received.";
    }
}
