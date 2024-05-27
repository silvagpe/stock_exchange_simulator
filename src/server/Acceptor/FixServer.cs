
using QuickFix;

namespace server.Acceptor
{
    public class FixServer : BackgroundService
    {
        private readonly ILogger<FixServer> _logger;
        private readonly IApplication _appFixServer;

        public FixServer(ILogger<FixServer> logger, IApplication appFixServer)
        {
            _logger = logger;
            _appFixServer = appFixServer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("[Acceptor] Starting Fix Server");


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
