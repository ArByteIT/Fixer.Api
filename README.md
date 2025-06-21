# Fixer.Api.Client

A simple, strongly-typed, and configurable .NET API client for the [Fixer.io](https://fixer.io) currency exchange rates API.  
Supports latest rates, historical data, currency conversion, time series, and fluctuations with built-in error handling and easy DI integration.

---

## Features

- Retrieve latest exchange rates with optional base currency and symbols filter  
- Fetch historical exchange rates for specific dates  
- Convert currency amounts between currencies  
- Query time series and fluctuation data  
- Automatic error handling with explicit exceptions for API errors  
- Supports cancellation tokens for async calls  
- Easy integration with `IHttpClientFactory` and Dependency Injection

---

## Installation

Install the NuGet package via:

```bash
dotnet add package Fixer.Api.Client
````

---

## Getting Started

### Registering the client

Configure your services in `Startup.cs` or wherever you configure DI:

```csharp
services.AddFixerClient(Configuration.GetSection("Fixer"));
```

Your configuration should include at least:

```json
{
  "Fixer": {
    "ApiKey": "your_api_key_here",
    "BaseUrl": "https://data.fixer.io/api/"
  }
}
```

---

### Usage example

Inject `IFixerClient` into your service or controller:

```csharp
public class CurrencyService
{
    private readonly IFixerClient _fixerClient;

    public CurrencyService(IFixerClient fixerClient)
    {
        _fixerClient = fixerClient;
    }

    public async Task PrintLatestRatesAsync()
    {
        var response = await _fixerClient.GetLatestRatesAsync(baseSymbol: "EUR", symbols: new[] { "USD", "GBP" });
        if (response?.Success == true)
        {
            foreach (var rate in response.Rates)
            {
                Console.WriteLine($"{rate.Key}: {rate.Value}");
            }
        }
    }
}
```

---

## Error Handling

API errors throw explicit exceptions derived from `FixerApiException` such as:

* `BadRequestException` (400)
* `UnauthorizedException` (401)
* `TooManyRequestsException` (429)
* And others per the Fixer API error codes

Use try-catch blocks to handle these gracefully.

---

## Testing

Includes integration tests using xUnit to verify live API behavior.
Configure your `FIXER_API_KEY` environment variable before running tests.

---

## Contributing

Contributions welcome! Please open issues or pull requests.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Links

* [Fixer.io API Documentation](https://fixer.io/documentation)
* [NuGet Package](https://www.nuget.org/packages/Fixer.Api.Client/1.0.0)
