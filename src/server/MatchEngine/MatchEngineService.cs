using server.FixServer.Observer;

namespace server.MatchEngine
{
    public class MatchEngineService : IMatchEngineService
    {
        private readonly ILogger<MatchEngineService> _logger;
        private readonly IApplicationSubject _applicationSubject;

        public MatchEngineService(
            ILogger<MatchEngineService> logger,
            IApplicationSubject applicationSubject)
        {
            _logger = logger;
            _applicationSubject = applicationSubject;
            _applicationSubject.FromAppNotification += ApplicationSubject_FromAppNotification;
            _applicationSubject.FromAdminNotification += ApplicationSubject_FromAdminNotification;
        }

        private void ApplicationSubject_FromAdminNotification(object? sender, (QuickFix.SessionID, QuickFix.Message) e)
        {
            _logger.LogInformation($"{nameof(ApplicationSubject_FromAdminNotification)}. Sernder: {sender} - SessionId: {e.Item1}, Message: {e.Item2}");
        }

        private void ApplicationSubject_FromAppNotification(object? sender, (QuickFix.SessionID, QuickFix.Message) e)
        {
            _logger.LogInformation($"{nameof(ApplicationSubject_FromAppNotification)}. Sernder: {sender} - SessionId: {e.Item1}, Message: {e.Item2}");
        }

        public void Start()
        {
            _logger.LogInformation($"{nameof(MatchEngineService)}: Started");
        }
    }
}
