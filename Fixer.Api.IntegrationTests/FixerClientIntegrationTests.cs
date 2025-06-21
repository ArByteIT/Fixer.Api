using Fixer.Api.Client;
using Fixer.Api.Client.Constants;
using Fixer.Api.Client.Interfaces;
using Fixer.Api.Client.Models;
using Fixer.Api.Client.Options;
using Microsoft.Extensions.Options;

namespace Fixer.Api.IntegrationTests;

public class FixerClientIntegrationTests
{
    private readonly FixerClient _client;

    public FixerClientIntegrationTests()
    {
        DotNetEnv.Env.Load();

        var apiKey = Environment.GetEnvironmentVariable("FIXER_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("Set FIXER_API_KEY environment variable before running tests.");

        var options = Options.Create(new FixerOptions
        {
            ApiKey = apiKey
        });

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(options.Value.BaseUrl)
        };

        _client = new FixerClient(httpClient, options);
    }

    [Fact]
    public async Task GetLatestRatesAsync_DefaultRequest_ReturnsSuccessAndRates()
    {
        var request = new LatestRatesRequest();

        var response = await _client.GetLatestRatesAsync(request);

        Assert.NotNull(response);
        Assert.True(response.Success, "Expected Success == true");
        Assert.NotNull(response.Rates);
        Assert.NotEmpty(response.Rates);
    }

    [Fact]
    public async Task GetSupportedSymbolsAsync_ReturnsSuccessAndSymbols()
    {
        var response = await _client.GetSupportedSymbolsAsync();

        Assert.NotNull(response);
        Assert.True(response.Success, "Expected Success == true");
        Assert.NotNull(response.Symbols);
        Assert.NotEmpty(response.Symbols);
    }

    [Fact]
    public async Task GetSupportedSymbolsAsync_ReturnsKnownCurrencySymbols()
    {
        var response = await _client.GetSupportedSymbolsAsync();

        Assert.NotNull(response);
        Assert.True(response.Success, "Expected Success == true");

        // Check that all symbols are known currencies
        foreach (var symbol in response.Symbols)
        {
            Assert.Contains(symbol.Key, CurrencySymbol.All);
        }
    }
}