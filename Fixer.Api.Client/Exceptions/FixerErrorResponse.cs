using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Exceptions;

internal class FixerErrorResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("error")]
    public FixerError? Error { get; set; }
}
