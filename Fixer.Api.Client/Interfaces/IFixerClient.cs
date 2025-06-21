using Fixer.Api.Client.Models;

namespace Fixer.Api.Client.Interfaces;

public interface IFixerClient
{
    /// <summary>
    /// Retrieves the list of supported currency symbols from Fixer API.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="SupportedSymbolsResponse"/> containing supported currency symbols or null if none returned.</returns>
    /// <exception cref="FixerApiException">Thrown when the Fixer API returns an error.</exception>
    Task<SupportedSymbolsResponse?> GetSupportedSymbolsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the latest exchange rates from Fixer API.
    /// </summary>
    /// <param name="baseSymbol">The base currency symbol (optional).</param>
    /// <param name="symbols">An array of target currency symbols to filter (optional).</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="LatestRatesResponse"/> containing the latest exchange rates or null if none returned.</returns>
    public Task<LatestRatesResponse?> GetLatestRatesAsync(
        string? baseSymbol = null, 
        string[]? symbols = null, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// https://fixer.io/documentation#latestrates
    /// </summary>
    /// <param name="request">The request containing base and symbols.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Latest exchange rates from Fixer.</returns>
    /// <exception cref="FixerApiException">
    /// Thrown when the Fixer API returns an error response (e.g., invalid key, quota exceeded, bad symbols).
    /// </exception>
    Task<LatestRatesResponse?> GetLatestRatesAsync(LatestRatesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves historical exchange rates for a specified date from Fixer API.
    /// </summary>
    /// <param name="historyDate">The date to retrieve historical rates for.</param>
    /// <param name="baseSymbol">The base currency symbol (optional).</param>
    /// <param name="symbols">An array of target currency symbols to filter (optional).</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="HistoricalRateResponse"/> containing historical rates or null if none returned.</returns>
    Task<HistoricalRateResponse?> GetHistoricalRatesAsync(
        DateTime historyDate,
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves historical exchange rates for a specified date from Fixer API.
    /// </summary>
    /// <param name="request">The request containing the historical date, base currency, and optional target symbols.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="HistoricalRateResponse"/> containing historical rates or null if none returned.</returns>
    /// <exception cref="FixerApiException">Thrown when the Fixer API returns an error (e.g. invalid date, symbols).</exception>
    Task<HistoricalRateResponse?> GetHistoricalRatesAsync(HistoricalRateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Converts an amount from one currency to another using Fixer API.
    /// </summary>
    /// <param name="from">The source currency code.</param>
    /// <param name="to">The target currency code.</param>
    /// <param name="amount">The amount to convert.</param>
    /// <param name="date">The date for historical conversion (optional).</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="ConvertCurrencyResponse"/> containing the conversion result or null if none returned.</returns>
    public Task<ConvertCurrencyResponse?> ConvertCurrencyAsync(
        string from,
        string to,
        decimal amount,
        DateTime? date = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Converts an amount from one currency to another using Fixer API.
    /// </summary>
    /// <param name="request">The request containing from/to currencies, amount, and optional date.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="ConvertCurrencyResponse"/> containing the conversion result or null if none returned.</returns>
    /// <exception cref="FixerApiException">Thrown when the Fixer API returns an error (e.g. invalid currencies, invalid amount).</exception>
    Task<ConvertCurrencyResponse?> ConvertCurrencyAsync(ConvertCurrencyRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves time series exchange rate data for a given date range from Fixer API.
    /// </summary>
    /// <param name="startDate">The start date of the time series.</param>
    /// <param name="endDate">The end date of the time series.</param>
    /// <param name="baseSymbol">The base currency symbol (optional).</param>
    /// <param name="symbols">An array of target currency symbols to filter (optional).</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="TimeSeriesResponse"/> containing time series data or null if none returned.</returns>
    Task<TimeSeriesResponse?> GetTimeSeriesAsync(
        DateTime startDate,
        DateTime endDate,
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves time series exchange rate data for a given date range from Fixer API.
    /// </summary>
    /// <param name="request">The request containing start and end dates, base currency, and optional target symbols.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="TimeSeriesResponse"/> containing time series data or null if none returned.</returns>
    /// <exception cref="FixerApiException">Thrown when the Fixer API returns an error (e.g. invalid date range, symbols).</exception>
    Task<TimeSeriesResponse?> GetTimeSeriesAsync(TimeSeriesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves currency fluctuation data for a given date range from Fixer API.
    /// </summary>
    /// <param name="startDate">The start date of the fluctuation period.</param>
    /// <param name="endDate">The end date of the fluctuation period.</param>
    /// <param name="baseSymbol">The base currency symbol (optional).</param>
    /// <param name="symbols">An array of target currency symbols to filter (optional).</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="FluctuationResponse"/> containing fluctuation data or null if none returned.</returns>
    Task<FluctuationResponse?> GetFluctuationAsync(
        DateTime startDate,
        DateTime endDate,
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves currency fluctuation data for a given date range from Fixer API.
    /// </summary>
    /// <param name="request">The request containing start and end dates, base currency, and optional target symbols.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="FluctuationResponse"/> containing fluctuation data or null if none returned.</returns>
    /// <exception cref="FixerApiException">Thrown when the Fixer API returns an error (e.g. invalid date range, symbols).</exception>
    Task<FluctuationResponse?> GetFluctuationAsync(FluctuationRequest request, CancellationToken cancellationToken = default);
}
