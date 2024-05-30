using QuickFix;
using System.Diagnostics.CodeAnalysis;

namespace server.Acceptor
{
    [ExcludeFromCodeCoverage]
    public static class AcceptorDependencyInjectionExtension
    {
        public static void ConfigureAcceptor(this IServiceCollection services)
        {
            services.AddSingleton<IApplication, FixServerApp>();
            services.AddHostedService<FixServer>();
        }
    }
}
