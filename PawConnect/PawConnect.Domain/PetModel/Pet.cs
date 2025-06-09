using CSharpFunctionalExtensions;
using PawConnect.Domain.ValueObjects;

namespace PawConnect.Domain.PetModel;

public class Pet : Entity
{
    private List<DonationDetails> _donationDetails = new();

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
    public IReadOnlyList<DonationDetails> DonationDetails => _donationDetails;
    public PetStatus Status { get; private set; }

    public static Result<Pet> Create(string name, string description, string contactNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name is required.");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description is required.");

        var phoneResult = PhoneNumber.Create(contactNumber);
        return phoneResult.IsFailure
            ? Result.Failure<Pet>(phoneResult.Error)
            : Result.Success(new Pet(name, description, phoneResult.Value));
    }
}