using CleanArchTemplate.Domain.ValueObjects;

namespace CleanArchTemplate.Domain.UnitTests.ValueObjects;

public class ContactPersonTests
{
    [Test]
    public void CreateContactPersonWhenAllPropertiesArePresentShouldCreateSuccessful()
    {
        var fullname = "John Doe";
        var phone = "555-1234-1";

        var contactPerson = new ContactPerson(fullname, phone);
        
        contactPerson.Fullname.Should().Be(fullname);
        contactPerson.Phone.Should().Be(phone);
    }

    [Test]
    public void CreateContactPersonWhenPropertiesAreNotPresentShuldThrowException([ValueSource(nameof(ContactData))] object[] contactData)
    {
        Action createContactPerson = () =>
        {
            var fullname = (string)contactData[0];
            var phone = (string)contactData[1];
            var contactPerson = new ContactPerson(fullname, phone);
        };
        createContactPerson.Should().Throw<ArgumentException>();
    }

    static object[] ContactData =
    {
        new object[] {"", "555-1234-1" },
        new object[] {"John Doe", ""}
    };
}
