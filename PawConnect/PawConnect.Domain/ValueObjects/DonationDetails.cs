using CSharpFunctionalExtensions;

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

    public static Result<DonationDetails> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<DonationDetails>("Title is required.");

        return (string.IsNullOrWhiteSpace(description))
            ? Result.Failure<DonationDetails>("Description is required.")
            : Result.Success(new DonationDetails(title, description));
    }
}