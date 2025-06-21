using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class Info
{
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("rate")]
    public decimal Rate { get; set; }
}
