using PawConnect.Domain.Shared;

namespace PawConnect.API.Response;

public class Envelope
{
    public object? Result { get; }
    public string? ErrorCode { get; }
    public string? ErrorMessage { get; }
    public DateTime TimeGenerated { get; }

    private Envelope(object? result, Error? error)
    {
        Result = result;
        ErrorCode = error?.Code;
        ErrorMessage = error?.Message;
        TimeGenerated = DateTime.UtcNow;
    }

    public static Envelope Ok(object? result = null) =>
        new(result, null);

    public static Envelope Error(Error error) =>
        new (null, error);
}

public class EnvelopeGeneric<T> where T : class
{
    public T? Result { get; }
    public string? ErrorCode { get; }
    public string? ErrorMessage { get; }
    public DateTime TimeGenerated { get; }

    private EnvelopeGeneric(T? result, Error? error)
    {
        Result = result;
        ErrorCode = error?.Code;
        ErrorMessage = error?.Message;
        TimeGenerated = DateTime.UtcNow;
    }

    public static EnvelopeGeneric<T> Ok(T? result = null) =>
        new(result, null);

    public static EnvelopeGeneric<T> Error(Error error) =>
        new (null, error);
}