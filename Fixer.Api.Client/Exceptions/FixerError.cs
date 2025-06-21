using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Exceptions;

internal class FixerError
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("info")]
    public string Info { get; set; } = string.Empty;
}
