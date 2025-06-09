using CSharpFunctionalExtensions;

namespace PawConnect.Domain.SpeciesModel;

public class Species : Entity
{
    private Species(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
    public List<Breed> Breeds { get; } = new();

    private static Result<Species> Create(string name)
    {
        return string.IsNullOrWhiteSpace(name)
            ? Result.Failure<Species>("Species name is required.")
            : Result.Success(new Species(name));
    }
}