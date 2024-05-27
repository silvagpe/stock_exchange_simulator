using QuickFix;
using QuickFix.Fields;

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

            var msgEr = new Message();
            msgEr.Header.SetField(new MsgType("8"));
            msgEr.Header.SetField(new ExecType('0')); // new
            msgEr.SetField(new ClOrdID("12345"));
            msgEr.SetField(new HandlInst('1'));
            msgEr.SetField(new Symbol("AAPL"));
            msgEr.SetField(new Side(Side.BUY));
            msgEr.SetField(new TransactTime(DateTime.UtcNow));
            msgEr.SetField(new OrdType(OrdType.MARKET));
            msgEr.SetField(new OrderQty(100));
            msgEr.SetField(new LastPx(150.25m));

            //var session = Session.LookupSession(sessionID);
            //session.Send(msgEr);

            Session.SendToTarget(msgEr, sessionID);
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

        public void ToApp(Message message, SessionID sessionID)
        {
            _logger.LogInformation($"{nameof(ToApp)} - {sessionID} - {message}");
            //throw new NotImplementedException();

            //try
            //{
            //    Session.SendToTarget(message, sessionID);
            //}
            //catch (SessionNotFound ex)
            //{
            //    _logger.LogError("Session not found: " + ex.Message);
            //}
        }
    }
}
