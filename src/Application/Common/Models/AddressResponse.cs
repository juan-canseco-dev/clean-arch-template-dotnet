using CleanArchTemplate.Domain.ValueObjects;

namespace CleanArchTemplate.Application.Common.Models;

public class AddressResponse
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
            CreateMap<Address, AddressResponse>();
        }
    }

}