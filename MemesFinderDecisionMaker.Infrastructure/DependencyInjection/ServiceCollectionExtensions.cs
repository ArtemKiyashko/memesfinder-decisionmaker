using Azure.Identity;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using MemesFinderDecisionMaker.Interfaces.DecisionMaker;
using MemesFinderDecisionMaker.Manager.DecisionMaker;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MemesFinderDecisionMaker.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDecisionManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RollDiceDecisionMakerOptions>(configuration.GetSection("RollDiceDecisionMakerOptions"));
            services.AddTransient<IDecisionMaker, RollDiceDecisionMaker>();

            services.AddTransient<IDecisionMakerManager, DecisionMakerManager>();
            return services;
        }

        public static IServiceCollection AddServiceTxtMessageClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceBusOptions>(configuration.GetSection("ServiceBusOptions"));

            services.AddAzureClients(clientBuilder =>
            {
                var provider = services.BuildServiceProvider();

                clientBuilder.UseCredential(new DefaultAzureCredential());
                clientBuilder.AddServiceBusClientWithNamespace(provider.GetRequiredService<IOptions<ServiceBusOptions>>().Value.FullyQualifiedNamespace);
            });

            services.AddTransient<IServiceBusClient, ServiceBusTxtMessageClient>();
            services.AddTransient<IServiceBusModelSender, ServiceBusTxtMessageClient>();
            return services;
        }

    }
}