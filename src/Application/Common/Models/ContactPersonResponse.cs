using CleanArchTemplate.Domain.ValueObjects;

namespace CleanArchTemplate.Application.Common.Models;


public class ContactPersonResponse
{
    public string? Fullname { get; init; }
    public string? Phone { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ContactPerson, ContactPersonResponse>();
        }
    }

}