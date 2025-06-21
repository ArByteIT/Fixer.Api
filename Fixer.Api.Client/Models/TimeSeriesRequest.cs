using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class TimeSeriesRequest
{
    [JsonPropertyName("start_date")]
    public required DateTime StartDate { get; set; }
    [JsonPropertyName("end_date")]
    public required DateTime EndDate { get; set; }
    [JsonPropertyName("base")]
    public string? BaseSymbol { get; set; }
    [JsonPropertyName("symbols")]
    public string[]? Symbols { get; set; }
}
