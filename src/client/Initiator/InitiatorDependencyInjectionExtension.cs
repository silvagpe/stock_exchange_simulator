using QuickFix;

namespace client.Initiator
{
    public static class InitiatorDependencyInjectionExtension
    {
        public static void ConfigureInitiator(this IServiceCollection services)
        {
            services.AddSingleton<IApplication, FixClientApp>();
            services.AddHostedService<FixClientHostedService>();
            services.AddSingleton<IFixApplicationFacede, FixApplicationFacede>();
        }
    }
}
