namespace Fixer.Api.Client.Models;

public class LatestRatesRequest
{
    public string? BaseSymbol { get; set; }
    public string[]? Symbols { get; set; }
}
