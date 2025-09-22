using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;

namespace PawConnect.Domain.ValueObjects;

public record DonationDetails
{
    private DonationDetails(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; }
    public string Description { get; }

    public static Result<DonationDetails, Error> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsRequired(nameof(title));

        if (title.Length > DbConstants.TextLengthShort)
            return Errors.General.StringTooLong(nameof(title), DbConstants.TextLengthShort);

        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsRequired(nameof(description));

        return description.Length > DbConstants.TextLengthMedium
            ? Errors.General.StringTooLong(nameof(description), DbConstants.TextLengthMedium)
            : new DonationDetails(title, description);
    }
}