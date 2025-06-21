namespace Fixer.Api.Client.Options;

public class FixerOptions
{
    public const string SectionName = "Fixer";
    public const string HttpClientName = "Fixer";
    public string BaseUrl { get; set; } = "https://data.fixer.io/api/";
    public string? ApiKey { get; set; }
}
