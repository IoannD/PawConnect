namespace PawConnect.Domain.Shared;

public class Error
{
    public string Code { get; private set; }
    public string Message { get; private set; }
    public ErrorType Type { get; private set; }

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public static Error Validation(string code, string message)
        => new Error(code,  message, ErrorType.Validation);

    public static Error Failure(string code, string message)
        => new Error(code,  message, ErrorType.Failure);

    public static Error NotFound(string code, string message)
        => new Error(code, message, ErrorType.NotFound);

    public static Error Conflict(string code, string message)
        => new Error(code,  message, ErrorType.Conflict);
}