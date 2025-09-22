using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;

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

    public static Result<SocialNetworkDetails, Error> Create(string title, string url)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsRequired(nameof(title));

        if (title.Length > DbConstants.TextLengthShort)
            return Errors.General.StringTooLong(nameof(title), DbConstants.TextLengthShort);

        if (string.IsNullOrWhiteSpace(url))
            return Errors.General.ValueIsRequired(nameof(url));

        return url.Length > DbConstants.TextLengthLong
            ? Errors.General.StringTooLong(nameof(url), DbConstants.TextLengthLong)
            : new SocialNetworkDetails(title, url);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        yield return Url;
    }
}