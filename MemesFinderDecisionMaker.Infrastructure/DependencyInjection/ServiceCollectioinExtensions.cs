using MemesFinderDecisionMaker.Interfaces.DecisionMaker;
using MemesFinderDecisionMaker.Manager.DecisionMaker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MemesFinderDecisionMaker.Infrastructure.DependencyInjection
{
    public static class ServiceCollectioinExtensions
    {
        public static IServiceCollection AddDecisionManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RollDiceDecisionMakerOptions>(configuration.GetSection("RollDiceDecisionMakerOptions"));
            services.AddTransient<IDecisionMaker, RollDiceDecisionMaker>();

            services.AddTransient<IDecisionMakerManager, DecisionMakerManager>();
            return services;
        }
    }
}