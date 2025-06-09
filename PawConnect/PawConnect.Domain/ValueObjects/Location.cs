using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public class Location : ValueObject
{
    private Location(string postalCode, string country, string city,
        string street, string buildingNumber)
    {
        PostalCode = postalCode;
        Country = country;
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
    }

    public string PostalCode { get; }
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string BuildingNumber { get; }

    public static Result<Location> Create(string postalCode, string country,
        string city, string street, string buildingNumber)
    {
        if (string.IsNullOrWhiteSpace(postalCode))
            return Result.Failure<Location>("Postal code is required.");

        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<Location>("Country is required.");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Location>("City is required.");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Location>("Street is required.");

        return string.IsNullOrWhiteSpace(buildingNumber)
            ? Result.Failure<Location>("Building number is required.")
            : Result.Success(new Location(postalCode, country, city, street, buildingNumber));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PostalCode;
        yield return Country;
        yield return City;
        yield return Street;
        yield return BuildingNumber;
    }
}