namespace PawConnect.Domain.Shared;

public enum ErrorType
{
    Unknown = 0,
    Validation,
    Failure,
    NotFound,
    Conflict
}