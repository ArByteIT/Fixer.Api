using Fixer.Api.Client.Interfaces;
using Fixer.Api.Client.Models;
using Fixer.Api.Client.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Fixer.Api.Client;

public class FixerClient : IFixerClient
{
    private readonly HttpClient _httpClient;
    private readonly FixerOptions _options;

    public FixerClient(HttpClient httpClient, IOptions<FixerOptions> options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    /// <inheritdoc />
    public async Task<SupportedSymbolsResponse?> GetSupportedSymbolsAsync(CancellationToken cancellationToken = default)
    {
        var parameters = GetDefaultParameters();

        var url = "symbols?" + BuildUrlParameters(parameters);

        return await _httpClient.GetFromJsonAsync<SupportedSymbolsResponse>(
            url,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task<LatestRatesResponse?> GetLatestRatesAsync(
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default)
    {
        var request = new LatestRatesRequest
        {
            BaseSymbol = baseSymbol,
            Symbols = symbols,
        };
        return GetLatestRatesAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<LatestRatesResponse?> GetLatestRatesAsync(LatestRatesRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = GetDefaultParameters();

        if (!string.IsNullOrEmpty(request.BaseSymbol))
        {
            parameters.Add("base", request.BaseSymbol);
        }

        if (request.Symbols != null && request.Symbols.Length > 0)
        {
            parameters.Add("symbols", string.Join(',', request.Symbols));
        }

        var url = "latest?" + BuildUrlParameters(parameters);

        return await _httpClient.GetFromJsonAsync<LatestRatesResponse>(
            url,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task<HistoricalRateResponse?> GetHistoricalRatesAsync(
        DateTime historyDate,
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HistoricalRateRequest
        {
            HistoryDate = historyDate,
            BaseSymbol = baseSymbol,
            Symbols = symbols
        };
        return GetHistoricalRatesAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HistoricalRateResponse?> GetHistoricalRatesAsync(HistoricalRateRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = GetDefaultParameters();

        if (!string.IsNullOrEmpty(request.BaseSymbol))
        {
            parameters.Add("base", request.BaseSymbol);
        }
        if (request.Symbols != null && request.Symbols.Length > 0)
        {
            parameters.Add("symbols", string.Join(',', request.Symbols));
        }

        var url = request.HistoryDate.ToString("yyyy-MM-dd") + "?" + BuildUrlParameters(parameters);

        return await _httpClient.GetFromJsonAsync<HistoricalRateResponse>(
            url,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task<ConvertCurrencyResponse?> ConvertCurrencyAsync(
        string from,
        string to,
        decimal amount,
        DateTime? date = null,
        CancellationToken cancellationToken = default)
    {
        var request = new ConvertCurrencyRequest
        {
            From = from,
            To = to,
            Amount = amount,
            DateTime = date
        };
        return ConvertCurrencyAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ConvertCurrencyResponse?> ConvertCurrencyAsync(ConvertCurrencyRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = GetDefaultParameters();

        parameters.Add("from", request.From);
        parameters.Add("to", request.To);
        parameters.Add("amount", request.Amount.ToString());

        if (request.DateTime.HasValue)
        {
            parameters.Add("date", request.DateTime.Value.ToString("yyyy-MM-dd"));
        }

        var url = "convert?" + BuildUrlParameters(parameters);

        return await _httpClient.GetFromJsonAsync<ConvertCurrencyResponse>(
            url,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task<TimeSeriesResponse?> GetTimeSeriesAsync(
        DateTime startDate,
        DateTime endDate,
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default)
    {
        var request = new TimeSeriesRequest
        {
            StartDate = startDate,
            EndDate = endDate,
            BaseSymbol = baseSymbol,
            Symbols = symbols
        };
        return GetTimeSeriesAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TimeSeriesResponse?> GetTimeSeriesAsync(TimeSeriesRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = GetDefaultParameters();

        parameters.Add("start_date", request.StartDate.ToString("yyyy-MM-dd"));
        parameters.Add("end_date", request.EndDate.ToString("yyyy-MM-dd"));

        if (!string.IsNullOrEmpty(request.BaseSymbol))
        {
            parameters.Add("base", request.BaseSymbol);
        }
        if (request.Symbols != null && request.Symbols.Length > 0)
        {
            parameters.Add("symbols", string.Join(',', request.Symbols));
        }

        var url = "timeseries?" + BuildUrlParameters(parameters);

        return await _httpClient.GetFromJsonAsync<TimeSeriesResponse>(
            url,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task<FluctuationResponse?> GetFluctuationAsync(
        DateTime startDate,
        DateTime endDate,
        string? baseSymbol = null,
        string[]? symbols = null,
        CancellationToken cancellationToken = default)
    {
        var request = new FluctuationRequest
        {
            StartDate = startDate,
            EndDate = endDate,
            BaseSymbol = baseSymbol,
            Symbols = symbols
        };
        return GetFluctuationAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FluctuationResponse?> GetFluctuationAsync(FluctuationRequest request, CancellationToken cancellationToken = default)
    {
        var parameters = GetDefaultParameters();

        parameters.Add("start_date", request.StartDate.ToString("yyyy-MM-dd"));
        parameters.Add("end_date", request.EndDate.ToString("yyyy-MM-dd"));

        if (!string.IsNullOrEmpty(request.BaseSymbol))
        {
            parameters.Add("base", request.BaseSymbol);
        }
        if (request.Symbols != null && request.Symbols.Length > 0)
        {
            parameters.Add("symbols", string.Join(',', request.Symbols));
        }

        var url = "fluctuation?" + BuildUrlParameters(parameters);

        return await _httpClient.GetFromJsonAsync<FluctuationResponse>(
            url,
            cancellationToken);
    }

    private Dictionary<string, string> GetDefaultParameters()
    {
        var parameters = new Dictionary<string, string>();

        if (!string.IsNullOrEmpty(_options.ApiKey))
        {
            parameters.Add("access_key", _options.ApiKey);
        }

        return parameters;
    }

    private static string BuildUrlParameters(Dictionary<string, string> parameters)
    {
        return string.Join('&', parameters.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));
    }
}
