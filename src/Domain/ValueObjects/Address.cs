namespace CleanArchTemplate.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Country { get; set; } = default!;
    public string State { get; set; } = default!;
    public string City { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
    public string Street { get; set; } = default!;

    // Required By EF
    private Address() { }
    public Address(string country, string state, string city, string zipCode, string street)
    {
        Guard.Against.NullOrEmpty(country, nameof(country));
        Guard.Against.NullOrEmpty(state, nameof(state));
        Guard.Against.NullOrEmpty(city, nameof(city));
        Guard.Against.NullOrEmpty(zipCode, nameof(zipCode));
        Guard.Against.NullOrEmpty(street, nameof(street));

        Country = country;
        State = state; 
        City = city;
        ZipCode = zipCode;
        Street = street;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return State;
        yield return City;
        yield return ZipCode;
        yield return Street;
    }
}
