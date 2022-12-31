using MemesFinderDecisionMaker.Clients;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MemesFinderDecisionMaker.Startup))]
namespace MemesFinderDecisionMaker
{
    internal class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig;
        public override void Configure(IFunctionsHostBuilder builder)
        {
            _functionConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.Configure<ServiceBusOptions>(_functionConfig.GetSection("ServiceBusOptions"));
            builder.Services.AddTransient<IServiceBusClient, ServiceBusTxtMessageClient>();
            builder.Services.AddLogging();
        }
    }
}
