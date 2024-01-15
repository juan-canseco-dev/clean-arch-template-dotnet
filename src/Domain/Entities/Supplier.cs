namespace CleanArchTemplate.Domain.Entities;

public class Supplier : BaseAuditableEntity<int>
{
    public string Name { get; private set;  }
    public string Phone { get; private set; }
    public Address Address { get; private set; }
    public ContactPerson ContactPerson { get; private set; }

    // Required By Ef Core
    private Supplier() 
    {
        Name = default!;
        Phone = default!;
        Address = default!;
        ContactPerson = default!;
    }

    public Supplier(int id, string name, string phone, Address address, ContactPerson contactPerson)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(phone, nameof(phone));
        Guard.Against.Null(address, nameof(address));
        Guard.Against.Null(contactPerson, nameof(contactPerson));

        Id = id;
        Name = name;
        Phone = phone;
        Address = address;
        ContactPerson = contactPerson;
    }


    public Supplier(string name, string phone, Address address, ContactPerson contactPerson)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(phone, nameof(phone));
        Guard.Against.Null(address, nameof(address));
        Guard.Against.Null(contactPerson, nameof(contactPerson));

        Name = name;
        Phone = phone;
        Address = address;
        ContactPerson = contactPerson;
    }

    public void Update(string name, string phone, Address address, ContactPerson contactPerson)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(phone, nameof(phone));
        Guard.Against.Null(address, nameof(address));
        Guard.Against.Null(contactPerson, nameof(contactPerson));

        Name = name;
        Phone = phone;
        Address = address;
        ContactPerson = contactPerson;
    }

}
