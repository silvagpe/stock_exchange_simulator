
using QuickFix;
using server.FixServer.SessionManager;
using server.MatchEngine;

namespace server.FixServer.Acceptor
{
    public class FixServerAcceptor : BackgroundService
    {
        private readonly ILogger<FixServerAcceptor> _logger;
        private readonly IApplication _appFixServer;
        private readonly ISessionManagerService _sessionManager;
        private readonly IMatchEngineService _matchEngineService;

        public FixServerAcceptor(
            ILogger<FixServerAcceptor> logger,
            IApplication appFixServer,
            ISessionManagerService sessionManager,
            IMatchEngineService matchEngineService)
        {
            _logger = logger;
            _appFixServer = appFixServer;
            _sessionManager = sessionManager;
            _matchEngineService = matchEngineService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("[Acceptor] Starting Fix Server");
            _sessionManager.Start();
            _matchEngineService.Start();

            SessionSettings settings = new SessionSettings(@"acceptor.cfg");

            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            ThreadedSocketAcceptor acceptor = new ThreadedSocketAcceptor(
                _appFixServer,
                storeFactory,
                settings,
                logFactory);

            acceptor.Start();
            stoppingToken.Register(() =>
            {
                _logger.LogInformation("[Acceptor] Stopping Fix Server");
                acceptor.Stop();
                _logger.LogInformation("[Acceptor] Stopped Fix Server");
            });

            _logger.LogInformation("[Acceptor] Started Fix Server");

            return Task.CompletedTask;
        }
    }
}
