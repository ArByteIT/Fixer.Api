using System.Text.Json;

namespace Fixer.Api.Client.Exceptions;

public sealed class FixerApiErrorHandler : DelegatingHandler
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new FixerApiException($"Fixer API returned HTTP {(int)response.StatusCode}: {response.ReasonPhrase}. Response: {content}");
        }

        try
        {
            var errorResponse = JsonSerializer.Deserialize<FixerErrorResponse>(content, _jsonSerializerOptions);

            if (errorResponse != null && !errorResponse.Success && errorResponse.Error != null)
            {
                ThrowFixerApiException(errorResponse.Error);
            }
        }
        catch (JsonException)
        {
            // Malformed JSON - optionally ignore here, or throw depending on how strict you want to be
            // For now, ignore and let downstream handle invalid JSON
        }

        return response;
    }

    private static void ThrowFixerApiException(FixerError error)
    {
        switch (error.Code)
        {
            case 400:
                throw new BadRequestException(error.Info);
            case 401:
                throw new UnauthorizedException(error.Info);
            case 403:
                throw new ForbiddenException(error.Info);
            case 404:
                throw new NotFoundException(error.Info);
            case 429:
                throw new TooManyRequestsException(error.Info);
            case 601:
                throw new InvalidBaseCurrencyException(error.Info);
            case 602:
                throw new InvalidSymbolsException(error.Info);
            case 603:
                throw new InvalidDateException(error.Info);
            case 604:
                throw new InvalidAmountException(error.Info);
            case 605:
                throw new InvalidTimeframeException(error.Info);
            case 606:
                throw new WeekendDataUnavailableException(error.Info);
            default:
                throw new FixerApiException($"Fixer API error {error.Code}: {error.Info}", error.Code);
        }
    }
}