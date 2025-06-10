using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public class Species : ValueObject
{
    private Species(Guid speciesId)
    {
        SpeciesId = speciesId;
    }
    public Guid SpeciesId { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SpeciesId;
    }

    private static Result<Species> Create(Guid speciesId)
    {
        return (speciesId == Guid.Empty)
            ? Result.Failure<Species>("SpeciesId cannot be empty")
            : Result.Success(new Species(speciesId));
    }
}