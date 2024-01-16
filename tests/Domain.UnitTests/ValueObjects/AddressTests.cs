namespace CleanArchTemplate.Domain.UnitTests.ValueObjects;

public class AddressTests
{
    [Test]
    public void CreateAddressWhenAllPropertiesArePresentShouldCreateSuccessful()
    {
        var country = "Mexico";
        var state = "Sonora";
        var city = "Hermosillo";
        var zipCode = "83200";
        var street = "Center";

        var address = new Address(country, state, city, zipCode, street);

        address.Country.Should().Be(country);
        address.State.Should().Be(state);
        address.City.Should().Be(city);
        address.ZipCode.Should().Be(zipCode);
        address.Street.Should().Be(street);
    }

    [Test]
    public void CreateAddressWhenPropertiesAreNotPresentShouldThrowException([ValueSource(nameof(AddressData))] object[] addressData)
    {
        Action createAddress = () =>
        {
            string country = (string)addressData[0]; 
            string state = (string)addressData[1];
            string city = (string)addressData[2];
            string zipCode = (string)addressData[3];
            string street = (string)addressData[4];

            var address = new Address(country, state, city, zipCode, street);
        };

        createAddress.Should().Throw<ArgumentException>();

    }


    static readonly object[] AddressData =
    {
        new object[] {"" , "Sonora", "Hermosillo", "83200", "Center"},
        new object[] {"Mexico" , "", "Hermosillo", "83200", "Center"},
        new object[] {"Mexico" , "Sonora", "", "83200", "Center"},
        new object[] {"Mexico" , "Sonora", "Hermosillo", "", "Center"},
        new object[] {"Mexico", "Sonora", "Hermosillo", "83200", "" }
    };

}
