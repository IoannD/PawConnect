using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public partial class Email : ValueObject
{
    private static readonly Regex EmailRegex = EmailRegexGenerate();

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Email> Create(string email)
    {
        return EmailRegex.IsMatch(email)
            ? Result.Success(new Email(email))
            : Result.Failure<Email>("Invalid email.");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegexGenerate();
}