using System.Diagnostics.CodeAnalysis;

namespace server.MatchEngine.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class MatchEngineDependencyInjectionExtension
    {
        public static void ConfigureMatchEngine(this IServiceCollection services)
        {
            services.AddSingleton<IMatchEngineService, MatchEngineService>();
        }
    }
}
