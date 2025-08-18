using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public record Breed
{
    private Breed(Guid breedId)
    {
        BreedId = breedId;
    }

    public Guid BreedId { get; }

    private static Result<Breed> Create(Guid breedId)
    {
        return breedId == Guid.Empty
            ? Result.Failure<Breed>("Breed Id cannot be empty")
            : Result.Success(new Breed(breedId));
    }
}