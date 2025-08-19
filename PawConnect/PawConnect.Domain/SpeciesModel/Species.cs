using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;

namespace PawConnect.Domain.SpeciesModel;

public class Species : Entity
{
    private List<Breed> _breeds = [];

    [Obsolete("Only for EF Core", true)]
    public Species()
    {
    }

    private Species(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
    public IReadOnlyList<Breed> Breeds => _breeds;

    private static Result<Species, Error> Create(string name)
    {
        return string.IsNullOrWhiteSpace(name)
            ? Result.Failure<Species, Error>(Errors.General.ValueIsRequired("species name"))
            : Result.Success<Species, Error>(new Species(name));
    }
}