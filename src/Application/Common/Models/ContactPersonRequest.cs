using CleanArchTemplate.Domain.ValueObjects;

namespace CleanArchTemplate.Application.Common.Models;

public class ContactPersonRequest
{
    public string? Fullname { get; init; }
    public string? Phone { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ContactPersonRequest, ContactPerson>();
        }
    }

}

public class ContactPersonRequestValidator : AbstractValidator<ContactPersonRequest>
{
    public ContactPersonRequestValidator()
    {
        RuleFor(c => c.Fullname)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(c => c.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(20);

    }
}
