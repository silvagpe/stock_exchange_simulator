using QuickFix;
using server.FixServer.Acceptor;
using server.FixServer.Observer;
using server.FixServer.SessionManager;
using System.Diagnostics.CodeAnalysis;

namespace server.FixServer.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class MatchEngineDependencyInjectionExtension
    {
        public static void ConfigureAcceptor(this IServiceCollection services)
        {
            services.AddSingleton<IApplication, FixServerApp>();
            services.AddSingleton<IApplicationSubject, ApplicationSubject>();
            services.AddSingleton<ISessionManagerService, SessionManager.SessionManagerService>();

            services.AddHostedService<FixServerAcceptor>();
        }
    }
}
