namespace PawConnect.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error InvalidValue(string? name = null)
            => Error.Validation("value_is_invalid", $"{name ?? "value"} is invalid");

        public static Error ValueIsRequired(string? name = null)
            => Error.Validation("value_is_required", $"{name ?? "value"} is required");

        public static Error StringTooLong(string? name = null, int? maxLength = null)
        {
            var msg = string.Concat($"{name ?? "string"} is too long.",
                maxLength != null ? " Maximum length is {maxLength} characters." : "");
            return Error.Validation("string_is_too_long", msg);
        }

        public static Error NotFound(Guid? id = null)
            => Error.NotFound("record_is_not_found", $"record with (id={id ?? Guid.Empty}) is not found");
    }
}