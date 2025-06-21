using System.Text.Json.Serialization;

namespace Fixer.Api.Client.Models;

public class FluctuationRate
{

    [JsonPropertyName("start_rate")]
    public decimal StartRate { get; set; }

    [JsonPropertyName("end_rate")]
    public decimal EndRate { get; set; }

    [JsonPropertyName("change")]
    public decimal Change { get; set; }

    [JsonPropertyName("change_pct")]
    public decimal ChangePct { get; set; }
}