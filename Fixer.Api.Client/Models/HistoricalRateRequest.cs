namespace Fixer.Api.Client.Models;

public class HistoricalRateRequest
{
    public required DateTime HistoryDate { get; set; }
    public string? BaseSymbol { get; set; }
    public string[]? Symbols { get; set; }
}
