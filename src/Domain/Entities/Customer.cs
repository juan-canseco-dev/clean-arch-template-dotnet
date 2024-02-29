
namespace CleanArchTemplate.Domain.Entities;

public class Customer : BaseAuditableEntity<int>
{
    public string IdentificationCode { get; private set; }
    public ContactPerson ContactPerson { get; private set; }
    public Address Address { get; private set; }

    public void Update(ContactPerson contactPerson, Address address)
    {
        Guard.Against.Null(contactPerson, nameof(contactPerson));
        Guard.Against.Null(address, nameof(address));
        ContactPerson = contactPerson;
        Address = address;
    }

    private Customer()
    {
        IdentificationCode = default!;
        ContactPerson = default!;
        Address = default!;
    }

    public Customer(string identificationCode, ContactPerson contactPerson, Address address)
    {
        Guard.Against.NullOrEmpty(identificationCode, nameof(identificationCode));
        Guard.Against.Null(contactPerson, nameof(contactPerson));
        Guard.Against.Null(address, nameof(address));

        IdentificationCode = identificationCode;
        ContactPerson = contactPerson;
        Address = address;
    }
}
