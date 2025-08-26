using Fixer.Api.Client.Exceptions;
using Fixer.Api.Client.Interfaces;
using Fixer.Api.Client.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fixer.Api.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddFixerClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FixerOptions>(configuration.GetRequiredSection(FixerOptions.SectionName));
        services.AddTransient<FixerApiErrorHandler>();

        return services.AddHttpClient<IFixerClient, FixerClient>(FixerOptions.HttpClientName, (provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<FixerOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        })
            .AddHttpMessageHandler<FixerApiErrorHandler>();
    }
}
