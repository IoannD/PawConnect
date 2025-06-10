using CSharpFunctionalExtensions;
using PawConnect.Domain.PetModel;
using PawConnect.Domain.ValueObjects;

namespace PawConnect.Domain;

public class Volunteer : Entity
{
    private List<Pet> _pets = [];
    private List<SocialNetwork> _socialNetworks = [];
    private List<DonationDetails> _donationDetails = [];
    private Volunteer(string firstName, string lastName, string middleName,
        string description, PhoneNumber phoneNumber, Email email)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Description = description;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public new Guid Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? MiddleName { get; private set; }
    public string Description { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public int ExperienceInYears { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;
    public IReadOnlyList<DonationDetails> DonationDetails => _donationDetails;
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    public int CountAdoptedPets => Pets.Count(p => p.Status == PetStatus.Adopted);
    public int CountLookingForHomePets => Pets.Count(p => p.Status == PetStatus.LookingForHome);
    public int CountNeedsHelpPets => Pets.Count(p => p.Status == PetStatus.NeedsHelp);

    public static Result<Volunteer> Create(string firstName, string lastName, string middleName,
        string description, PhoneNumber phoneNumber, Email email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Result.Failure<Volunteer>("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            return Result.Failure<Volunteer>("Last name is required.");

        if (string.IsNullOrWhiteSpace(middleName))
            middleName = null!;

        return string.IsNullOrWhiteSpace(description)
            ? Result.Failure<Volunteer>("Description is required.")
            : Result.Success(new Volunteer(firstName, lastName, middleName, description,
            phoneNumber, email));
    }
}