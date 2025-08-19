namespace PawConnect.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error InvalidValue(string? name = null)
            => Error.Validation("value_is_invalid", $"{name ?? "value"} is invalid");

        public static Error ValueIsRequired(string? name = null)
            => Error.Validation("value_is_required", $"{name ?? "value"} is required");

        public static Error NotFound(Guid? id = null)
            => Error.NotFound("record_is_not_found", $"record with (id={id ?? Guid.Empty}) is not found");
    }
}