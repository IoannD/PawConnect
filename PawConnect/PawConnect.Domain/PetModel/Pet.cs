using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;
using PawConnect.Domain.ValueObjects;

namespace PawConnect.Domain.PetModel;

public class Pet : Entity
{
    [Obsolete("Only for EF Core", true)]
    public Pet()
    {
    }

    private Pet(string name, string description, PhoneNumber contactNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        ContactNumber = contactNumber;
    }

    public Guid Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Species Species { get; private set; }
    public Breed Breed { get; private set; }
    public string Color { get; private set; }
    public Location Location { get; private set; }
    public string HealthInfo { get; private set; }
    public double WeightInKg { get; private set; }
    public double HeightInCm { get; private set; }
    public PhoneNumber ContactNumber { get; private set; }
    public bool IsCastrated { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsVaccinated { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Donation Donation { get; private set; }
    public PetStatus Status { get; private set; }

    public static Result<Pet, Error> Create(string name, string description, PhoneNumber contactNumber)
    {
        return string.IsNullOrWhiteSpace(name)
            ? Result.Failure<Pet, Error>(Errors.General.ValueIsRequired(nameof(name)))
            : Result.Success<Pet, Error>(new Pet(name, description, contactNumber));
    }
}