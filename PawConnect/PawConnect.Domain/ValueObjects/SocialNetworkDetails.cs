using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public class SocialNetworkDetails : ValueObject
{
    private SocialNetworkDetails(string title, string url)
    {
        Title = title;
        Url = url;
    }

    public string Title { get; }
    public string Url { get; }

    public static Result<SocialNetworkDetails> Create(string title, string url)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<SocialNetworkDetails>("Title is required.");

        return string.IsNullOrWhiteSpace(url)
            ? Result.Failure<SocialNetworkDetails>("Url is required.")
            : Result.Success(new SocialNetworkDetails(title, url));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Url;
    }
}