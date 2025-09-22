using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;

namespace PawConnect.Domain.ValueObjects;

public partial class Email : ValueObject
{
    private static readonly Regex EmailRegex = EmailRegexGenerate();

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Email, Error> Create(string email)
    {
        return EmailRegex.IsMatch(email)
            ? new Email(email)
            : Errors.General.InvalidValue(nameof(email));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegexGenerate();
}