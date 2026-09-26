using Azure.Identity;
using Azure.Messaging.ServiceBus;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using MemesFinderDecisionMaker.Interfaces.DecisionMaker;
using MemesFinderDecisionMaker.Manager.DecisionMaker;
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

            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ServiceBusOptions>>().Value;
                return new ServiceBusClient(options.FullyQualifiedNamespace, new DefaultAzureCredential());
            });

            services.AddTransient<IServiceBusClient, ServiceBusTxtMessageClient>();
            services.AddTransient<IServiceBusModelSender, ServiceBusTxtMessageClient>();
            return services;
        }

    }
}