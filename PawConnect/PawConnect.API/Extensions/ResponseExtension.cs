using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PawConnect.API.Response;
using PawConnect.Domain.Shared;

namespace PawConnect.API.Extensions;

public static class ResponseExtension
{
    public static ActionResult<EnvelopeGeneric<T>> ToResponse<T>(this UnitResult<Error> result) where T : class
    {
        if (result.IsSuccess)
            return new ObjectResult(Envelope.Ok());

        return new ObjectResult(Envelope.Error(result.Error))
        {
            StatusCode = GetStatusCode(result.Error)
        };
    }

    public static ActionResult<T> ToResponse<T>(this Result<T, Error> result)
    {
        if (result.IsSuccess)
            return new ObjectResult(Envelope.Ok(result.Value));

        return new ObjectResult(Envelope.Error(result.Error))
        {
            StatusCode = GetStatusCode(result.Error)
        };
    }

    private static int GetStatusCode(Error error)
    {
        return error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Failure  => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}