
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
            _logger.LogInformation("Starting Fix Client");


            SessionSettings settings = new SessionSettings(@"acceptor.cfg");

            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            ThreadedSocketAcceptor acceptor = new ThreadedSocketAcceptor(
                _appFixServer,
                storeFactory,
                settings,
                logFactory);

            acceptor.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("o hai");
                Thread.Sleep(1000);
            }
            acceptor.Stop();

            return Task.CompletedTask;
        }
    }
}
