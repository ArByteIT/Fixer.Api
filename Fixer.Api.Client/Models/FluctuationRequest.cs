using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class FluctuationRequest
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public string? BaseSymbol { get; set; }
    public string[]? Symbols { get; set; }
}

public class FluctuationResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("fluctuation")]
    public bool Fluctuation { get; set; }

    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("base")]
    public string? Base { get; set; }

    [JsonPropertyName("rates")]
    public Dictionary<string, FluctuationRate> Rates { get; set; } = new Dictionary<string, FluctuationRate>();
}
