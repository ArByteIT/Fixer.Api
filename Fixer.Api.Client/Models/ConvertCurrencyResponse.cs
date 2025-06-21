using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class ConvertCurrencyResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("query")]
    public Query? Query { get; set; }

    [JsonPropertyName("info")]
    public Info? Info { get; set; }

    [JsonPropertyName("historical")]
    public bool Historical { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("result")]
    public decimal Result { get; set; }
}
