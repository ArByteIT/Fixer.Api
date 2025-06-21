using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class SupportedSymbolsResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("symbols")]
    public Dictionary<string, string> Symbols { get; set; } = new Dictionary<string, string>();
}
