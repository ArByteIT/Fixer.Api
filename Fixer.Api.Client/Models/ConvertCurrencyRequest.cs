using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class ConvertCurrencyRequest
{
    [JsonPropertyName("from")]
    public required string From { get; set; }
    [JsonPropertyName("to")]
    public required string To { get; set; }
    [JsonPropertyName("amount")]
    public required decimal Amount { get; set; }
    public DateTime? DateTime { get; set; }
}
