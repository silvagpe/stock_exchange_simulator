using QuickFix;
using server.FixServer.Observer;

namespace server.FixServer.SessionManager
{
    public class SessionManagerService : ISessionManagerService
    {
        private readonly ILogger<SessionManagerService> _logger;
        private readonly IApplicationSubject _applicationSubject;
        private readonly Dictionary<string, SessionID> sessionIDs = new Dictionary<string, SessionID>();

        public SessionManagerService(
            ILogger<SessionManagerService> logger,
            IApplicationSubject applicationSubject)
        {
            _logger = logger;
            _applicationSubject = applicationSubject;
            _applicationSubject.OnCreateNotification += ApplicationSubject_OnCreateNotification;
        }

        private void ApplicationSubject_OnCreateNotification(object? sender, QuickFix.SessionID sessionId)
        {
            _logger.LogInformation($"Added session on memory. Sernder: {sender} - SessionId: {sessionId}");
            sessionIDs.Add(sessionId.ToString(), sessionId);
        }

        public void Start()
        {
            _logger.LogInformation($"{nameof(SessionManagerService)}: Started");
        }

        public SessionID? GetSession(string name)
        {
            return sessionIDs.TryGetValue(name, out var sessionID) ? sessionID : null;
        }
    }
}
