using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class Query
{
    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("to")]
    public string? To { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}