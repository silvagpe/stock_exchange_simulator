using QuickFix;
using QuickFix.Transport;

namespace client.Initiator
{
    public class FixClientHostedService : BackgroundService
    {
        private const string FIX_CLIENT_NAME = "Fix Client";
        private const string INITIATOR_CONFIG = "initiator.cfg";
        private readonly ILogger<FixClientHostedService> _logger;
        private readonly IApplication _appFixClient;

        public FixClientHostedService(ILogger<FixClientHostedService> logger, IApplication appFixServer)
        {
            _logger = logger;
            _appFixClient = appFixServer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Starting {FIX_CLIENT_NAME}");

            SessionSettings settings = new SessionSettings(INITIATOR_CONFIG);

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
                _logger.LogInformation($"Stopping {FIX_CLIENT_NAME}");
                initiator.Stop();
                _logger.LogInformation($"Stopped {FIX_CLIENT_NAME}");
            });
            _logger.LogInformation($"Started {FIX_CLIENT_NAME}");

            return Task.CompletedTask;
        }
    }
}
