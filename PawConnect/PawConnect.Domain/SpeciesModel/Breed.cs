using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;

namespace PawConnect.Domain.SpeciesModel;

public class Breed : Entity
{
    [Obsolete("Only for EF Core", true)]
    public Breed()
    {
    }
    private Breed(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }

    public static Result<Breed, Error> Create(string name)
    {
        return (string.IsNullOrWhiteSpace(name))
            ? Result.Failure<Breed, Error>(Errors.General.ValueIsRequired("breed name"))
            : Result.Success<Breed, Error>(new Breed(name));
    }
}