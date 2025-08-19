using CSharpFunctionalExtensions;
using PawConnect.Domain.PetModel;
using PawConnect.Domain.Shared;
using PawConnect.Domain.ValueObjects;

namespace PawConnect.Domain.VolunteerModel;

public class Volunteer : Entity
{
    [Obsolete("Only for EF Core", true)]
    public Volunteer()
    {
    }

    private List<Pet> _pets = [];

    private Volunteer(string firstName, string lastName, string? middleName,
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
    public Donation Donation { get; private set; }
    public SocialNetworks SocialNetworks { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;

    public int CountAdoptedPets => Pets.Count(p => p.Status == PetStatus.Adopted);
    public int CountLookingForHomePets => Pets.Count(p => p.Status == PetStatus.LookingForHome);
    public int CountNeedsHelpPets => Pets.Count(p => p.Status == PetStatus.NeedsHelp);

    public static Result<Volunteer, Error> Create(string firstName, string lastName, string middleName,
        string description, PhoneNumber phoneNumber, Email email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Errors.General.ValueIsRequired(nameof(firstName));

        if (firstName.Length > DbConstants.TextLengthShort)
            return Errors.General.StringTooLong(nameof(firstName), DbConstants.TextLengthShort);

        if (string.IsNullOrWhiteSpace(lastName))
            return Errors.General.ValueIsRequired(nameof(lastName));

        if (lastName.Length > DbConstants.TextLengthShort)
            return Errors.General.StringTooLong(nameof(lastName), DbConstants.TextLengthShort);

        if (string.IsNullOrWhiteSpace(middleName))
            middleName = null!;

        if (middleName != null! && middleName.Length > DbConstants.TextLengthShort)
            return Errors.General.StringTooLong(nameof(lastName), DbConstants.TextLengthShort);

        return string.IsNullOrWhiteSpace(description)
            ? Errors.General.ValueIsRequired(nameof(description))
            : new Volunteer(firstName, lastName, middleName, description, phoneNumber, email);
    }
}