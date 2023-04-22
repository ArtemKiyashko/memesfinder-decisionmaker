using MemesFinderDecisionMaker.Extentions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            builder.Services.AddServiceTxtMessageClient(_functionConfig);
            builder.Services.AddDecisionManager(_functionConfig);

            builder.Services.AddLogging(logBuilder =>
            {
                logBuilder.AddConsole();
            });
        }
    }
}
