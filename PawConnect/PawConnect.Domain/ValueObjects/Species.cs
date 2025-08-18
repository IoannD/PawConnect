using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public record Species
{
    private Species(Guid speciesId)
    {
        SpeciesId = speciesId;
    }

    public Guid SpeciesId { get; }

    private static Result<Species> Create(Guid speciesId)
    {
        return (speciesId == Guid.Empty)
            ? Result.Failure<Species>("SpeciesId cannot be empty")
            : Result.Success(new Species(speciesId));
    }
}