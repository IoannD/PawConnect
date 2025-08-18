using CSharpFunctionalExtensions;

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

    public static Result<Breed> Create(string name)
    {
        return (string.IsNullOrWhiteSpace(name))
            ? Result.Failure<Breed>($"Breed name is required.")
            : Result.Success(new Breed(name));
    }
}