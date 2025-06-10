using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public class Breed : ValueObject
{
    private Breed(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    private static Result<Breed> Create(Guid id)
    {
        return id == Guid.Empty
            ? Result.Failure<Breed>("Breed Id cannot be empty")
            : Result.Success(new Breed(id));
    }
}