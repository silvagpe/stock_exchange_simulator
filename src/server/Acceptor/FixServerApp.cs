using QuickFix;

namespace server.Acceptor
{
    public class FixServerApp : IApplication
    {
        private readonly ILogger<FixServerApp> _logger;

        public FixServerApp(ILogger<FixServerApp> logger)
        {
            _logger = logger;
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(FromAdmin)} - {message}");
            //throw new NotImplementedException();

        }

        public void FromApp(Message message, SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(FromApp)} - {message}");
            //throw new NotImplementedException();
        }

        public void OnCreate(SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(OnCreate)} - {sessionID}");
            //throw new NotImplementedException();
        }

        public void OnLogon(SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(OnLogon)} - {sessionID}");
            //throw new NotImplementedException();
        }

        public void OnLogout(SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(OnLogout)} - {sessionID}");
            //throw new NotImplementedException();
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(ToAdmin)} - {sessionID} - {message}");
            //throw new NotImplementedException();
        }

        public void ToApp(Message message, SessionID sessionId)
        {
            _logger.LogInformation($"{nameof(ToApp)} - {sessionId} - {message}");
            //throw new NotImplementedException();
        }
    }
}
