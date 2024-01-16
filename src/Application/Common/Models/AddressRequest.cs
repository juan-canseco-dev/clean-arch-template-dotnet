using CleanArchTemplate.Domain.ValueObjects;

namespace CleanArchTemplate.Application.Common.Models;

public class AddressRequest
{
    public string? Country { get; init; }
    public string? State { get; init; }
    public string? City { get; init; }
    public string? ZipCode { get; init; }
    public string? Street { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddressRequest, Address>();
        }
    }
}


public class AddressRequestValidator : AbstractValidator<AddressRequest>
{
    public AddressRequestValidator()
    {
        RuleFor(a => a.Country)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(a => a.State)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(a => a.City)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(a => a.ZipCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(a => a.Street)
            .NotEmpty()
            .MaximumLength(75);
    }
}
