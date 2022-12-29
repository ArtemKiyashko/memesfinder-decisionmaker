using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            builder.Services.AddLogging();
        }
    }
}
