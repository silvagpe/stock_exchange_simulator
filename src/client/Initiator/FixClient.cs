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
            _logger.LogInformation("Starting Fix Client");


            SessionSettings settings = new SessionSettings(@"initiator.cfg");

            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            SocketInitiator initiator = new SocketInitiator(
                _appFixClient,
                storeFactory,
                settings,
                logFactory);

            initiator.Start();
            stoppingToken.Register(() =>
            {
                _logger.LogInformation("Stopping Fix Client");
                initiator.Stop();
                _logger.LogInformation("Stopped Fix Client");
            });
            _logger.LogInformation("Started Fix Client");

            

            return Task.CompletedTask;
        }
    }
}
