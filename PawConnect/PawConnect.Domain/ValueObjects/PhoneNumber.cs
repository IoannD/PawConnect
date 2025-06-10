using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PawConnect.Domain.ValueObjects;

public partial class PhoneNumber : ValueObject
{
    private static readonly Regex PhoneRegex = PhoneRegexGenerate();

    private PhoneNumber(string phoneNumber)
    {
        Phone = phoneNumber;
    }

    public string Phone { get; }

    public static Result<PhoneNumber> Create(string phoneNumber)
    {
        return PhoneRegex.IsMatch(phoneNumber)
            ? Result.Success(new PhoneNumber(phoneNumber))
            : Result.Failure<PhoneNumber>("Invalid phone number.");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Phone;
    }

    [GeneratedRegex("^\\+?[1-9][0-9]{7,14}$")]
    private static partial Regex PhoneRegexGenerate();
}