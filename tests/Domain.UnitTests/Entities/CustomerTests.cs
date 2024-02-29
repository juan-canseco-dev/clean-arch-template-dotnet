namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class CustomerTests
{
    static readonly string IdentificationCode = "12345678910";
    static readonly ContactPerson ContactPerson = new(fullname: "John Doe", phone: "555-1234-2");
    static readonly Address Address = new(country: "Mexico", state: "Sonora", city: "Hermosillo", zipCode: "83200", street: "Center");

    [Test]
    public void CreateCustomerWhenPropertiesAreValidShouldCreateSuccessfully()
    {
        var customer = new Customer(IdentificationCode, ContactPerson, Address);
        customer.IdentificationCode.Should().Be(IdentificationCode);
        customer.ContactPerson.Should().Be(ContactPerson);
        customer.Address.Should().Be(Address);
    }

    [Test]
    public void CreateCustomerWhenPropertiesAreInvalidShouldThrowException([ValueSource(nameof(CreateCustomerData))] object[] customerData)
    {
        Action createCustomer = () =>
        {
            string identificationCode = (string)customerData[0];
            ContactPerson contactPerson = (ContactPerson)customerData[1];
            Address address = (Address)customerData[2];
            new Customer(identificationCode, contactPerson, address);
        };
        createCustomer.Should().Throw<ArgumentException>();
    }

    [Test]
    public void UpdateCustomerWhenArgumentsAreValidShouldUpdateSuccessfully()
    {
        var contactPerson = new ContactPerson(fullname: "John Doe Smith", phone: "555-1234-1");
        var address = new Address(country: "Mexico", state: "Sonora", city: "Hermosillo", zipCode: "83201", street: "Center");
        var customer = new Customer(IdentificationCode, ContactPerson, Address);
        customer.Update(contactPerson, address);
        customer.ContactPerson.Should().Be(contactPerson);
        customer.Address.Should().Be(address);
    }


    [Test]
    public void UpdateCustomerWhenArgumentsAreInvalidUpdateShouldThrowException([ValueSource(nameof(UpdateCustomerData))] object[] customerData)
    {
        Action updateCustomer = () =>
        {
            var updateContact = (ContactPerson)customerData[0];
            var updateAddress = (Address)customerData[1];
            var customer = new Customer(IdentificationCode, ContactPerson, Address);
            customer.Update(updateContact, updateAddress);
        };
        updateCustomer.Should().Throw<ArgumentException>();
    }

    static readonly object[] CreateCustomerData =
    {
        new object[] {null, ContactPerson, Address},
        new object[] {"", ContactPerson, Address},
        new object[] {IdentificationCode, null, Address},
        new object[] {IdentificationCode, ContactPerson, null}
    };

    static readonly object[] UpdateCustomerData =
    {
        new object[] {null, Address},
        new object[] {ContactPerson, null}
    };

}
