using System;
using System.Linq;
using System.Net.Http;
using Fixer.Api.Client.Extensions;
using Fixer.Api.Client.Interfaces;
using Fixer.Api.Client.Options;
using Fixer.Api.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using Fixer.Api.Client.Exceptions;

namespace Fixer.Api.IntegrationTests.Extensions;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddFixerClient_RegistersServicesCorrectly()
    {
        // Arrange
        var services = new ServiceCollection();

        // Simulate configuration
        Dictionary<string, string?>? inMemorySettings = new Dictionary<string, string?>
        {
            [$"{FixerOptions.SectionName}:BaseUrl"] = "https://data.fixer.io/api/",
            [$"{FixerOptions.SectionName}:ApiKey"] = "testkey"
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // Act
        services.AddFixerClient(configuration);

        var provider = services.BuildServiceProvider();

        // Assert FixerOptions configured
        var options = provider.GetRequiredService<IOptions<FixerOptions>>();
        Assert.Equal("https://data.fixer.io/api/", options.Value.BaseUrl);
        Assert.Equal("testkey", options.Value.ApiKey);

        // Assert IFixerClient registered and resolves to FixerClient
        var client = provider.GetService<IFixerClient>();
        Assert.NotNull(client);
        Assert.IsType<FixerClient>(client);

        // Assert HttpClient configured with correct BaseAddress
        var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient(FixerOptions.HttpClientName);
        Assert.Equal(new Uri("https://data.fixer.io/api/"), httpClient.BaseAddress);

        // Assert FixerApiErrorHandler registered in DI container
        var errorHandler = provider.GetService<FixerApiErrorHandler>();
        Assert.NotNull(errorHandler);
    }
}
