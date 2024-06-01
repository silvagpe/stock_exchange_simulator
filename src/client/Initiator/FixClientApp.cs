using QuickFix;
using QuickFix.Fields;

namespace client.Initiator
{
    public class FixClientApp : IApplication, IGetFixSession
    {
        private readonly ILogger<FixClientApp> _logger;

        private Session _session = null;

        public Session Session { get => _session; }

        public FixClientApp(ILogger<FixClientApp> logger)
        {
            _logger = logger;
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {

            var msgType = message.Header.GetField(Tags.MsgType);
            if (msgType == "0")
            {
                return;
            }

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
            _session = Session.LookupSession(sessionID);
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
