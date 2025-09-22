using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;

namespace PawConnect.Domain.ValueObjects;

public partial record PhoneNumber
{
    private static readonly Regex PhoneRegex = PhoneRegexGenerate();

    private PhoneNumber(string phone)
    {
        Phone = phone;
    }

    public string Phone { get; }

    public static Result<PhoneNumber, Error> Create(string phoneNumber)
    {
        return PhoneRegex.IsMatch(phoneNumber)
            ? new PhoneNumber(phoneNumber)
            : Errors.General.InvalidValue(nameof(phoneNumber));
    }

    [GeneratedRegex("^\\+?[1-9][0-9]{7,14}$")]
    private static partial Regex PhoneRegexGenerate();
}