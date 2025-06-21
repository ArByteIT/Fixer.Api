namespace Fixer.Api.Client.Exceptions;

/// <summary>
/// Represents errors returned by the Fixer API.
/// Contains an optional error code corresponding to the Fixer API error response.
/// </summary>
public class FixerApiException : Exception
{
    /// <summary>
    /// Gets the optional Fixer API error code associated with this exception.
    /// </summary>
    public int? ErrorCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FixerApiException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public FixerApiException(string message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FixerApiException"/> class with a specified error message and error code.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="errorCode">The Fixer API error code returned.</param>
    public FixerApiException(string message, int? errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FixerApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public FixerApiException(string message, Exception innerException)
        : base(message, innerException) { }
}

/// <summary>
/// The request was invalid or malformed (HTTP 400).
/// </summary>
public class BadRequestException : FixerApiException
{
    public BadRequestException(string message) : base(message, 400) { }
}

/// <summary>
/// No API key was specified or the API key is invalid (HTTP 401).
/// </summary>
public class UnauthorizedException : FixerApiException
{
    public UnauthorizedException(string message) : base(message, 401) { }
}

/// <summary>
/// The current subscription plan does not support this API endpoint (HTTP 403).
/// </summary>
public class ForbiddenException : FixerApiException
{
    public ForbiddenException(string message) : base(message, 403) { }
}

/// <summary>
/// The requested resource or endpoint does not exist (HTTP 404).
/// </summary>
public class NotFoundException : FixerApiException
{
    public NotFoundException(string message) : base(message, 404) { }
}

/// <summary>
/// The maximum allowed number of API requests per month has been reached (HTTP 429).
/// </summary>
public class TooManyRequestsException : FixerApiException
{
    public TooManyRequestsException(string message) : base(message, 429) { }
}

/// <summary>
/// An invalid base currency was specified (Fixer API error code 601).
/// </summary>
public class InvalidBaseCurrencyException : FixerApiException
{
    public InvalidBaseCurrencyException(string message) : base(message, 601) { }
}

/// <summary>
/// One or more invalid currency symbols were specified (Fixer API error code 602).
/// </summary>
public class InvalidSymbolsException : FixerApiException
{
    public InvalidSymbolsException(string message) : base(message, 602) { }
}

/// <summary>
/// No date or an invalid date was specified (Fixer API error code 603).
/// </summary>
public class InvalidDateException : FixerApiException
{
    public InvalidDateException(string message) : base(message, 603) { }
}

/// <summary>
/// No or an invalid amount was specified (Fixer API error code 604).
/// </summary>
public class InvalidAmountException : FixerApiException
{
    public InvalidAmountException(string message) : base(message, 604) { }
}

/// <summary>
/// No or an invalid timeframe was specified (Fixer API error code 605).
/// </summary>
public class InvalidTimeframeException : FixerApiException
{
    public InvalidTimeframeException(string message) : base(message, 605) { }
}

/// <summary>
/// Trading/markets are closed during the weekend; weekend data is not included in the response (Fixer API error code 606).
/// </summary>
public class WeekendDataUnavailableException : FixerApiException
{
    public WeekendDataUnavailableException(string message) : base(message, 606) { }
}
