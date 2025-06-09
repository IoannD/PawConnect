using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public class SocialNetwork : ValueObject
{
    private SocialNetwork(string title, string url)
    {
        Title = title;
        Url = url;
    }

    public string Title { get; }
    public string Url { get; }

    public static Result<SocialNetwork> Create(string title, string url)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<SocialNetwork>("Title is required.");

        return string.IsNullOrWhiteSpace(url)
            ? Result.Failure<SocialNetwork>("Url is required.")
            : Result.Success(new SocialNetwork(title, url));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Url;
    }
}