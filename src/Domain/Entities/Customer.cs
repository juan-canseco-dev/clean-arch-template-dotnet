
namespace CleanArchTemplate.Domain.Entities;

public class Customer : BaseAuditableEntity<int>
{
    public string IdentificationCode { get; private set; }
    public ContactPerson ContactPerson { get; private set; }
    public Address Address { get; private set; }

    private Customer()
    {
        IdentificationCode = default!;
        ContactPerson = default!;
        Address = default!;
    }
}
