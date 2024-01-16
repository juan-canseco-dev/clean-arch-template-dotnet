
namespace CleanArchTemplate.Domain.Exceptions;

public class NegativeProfitException : DomainException
{
    public NegativeProfitException() : base("Sale Price Must Be Greater Than Purchase Price.")
    {
    }
}
