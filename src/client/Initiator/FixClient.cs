using QuickFix;
using QuickFix.Transport;

namespace client.Initiator
{
    public class FixClient : BackgroundService
    {
        private readonly ILogger<FixClient> _logger;
        private readonly IApplication _appFixClient;

        public FixClient(ILogger<FixClient> logger, IApplication appFixServer)
        {
            _logger = logger;
            _appFixClient = appFixServer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting Fix Server");


            SessionSettings settings = new SessionSettings(@"initiator.cfg");

            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            SocketInitiator initiator = new SocketInitiator(
                _appFixClient,
                storeFactory,
                settings,
                logFactory);

            initiator.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("o hai");
                Thread.Sleep(1000);
            }
            initiator.Stop();

            return Task.CompletedTask;
        }
    }
}
