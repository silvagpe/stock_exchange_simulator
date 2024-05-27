using QuickFix;
using QuickFix.Fields;

namespace client.Initiator
{
    public class FixClientApp : IApplication, ITest
    {
        private readonly ILogger<FixClientApp> _logger;

        Session _session = null;

        public FixClientApp(ILogger<FixClientApp> logger)
        {
            _logger = logger;
        }

        public void TestConnection()
        {
            Message newOrder = new Message();
            newOrder.Header.SetField(new MsgType("D"));
            newOrder.SetField(new ClOrdID("12345"));
            newOrder.SetField(new HandlInst('1'));
            newOrder.SetField(new Symbol("AAPL"));
            newOrder.SetField(new Side(Side.BUY));
            newOrder.SetField(new TransactTime(DateTime.UtcNow));
            newOrder.SetField(new OrdType(OrdType.MARKET));
            newOrder.SetField(new OrderQty(100));
            newOrder.SetField(new Price(150.25m));

            try
            {
                _session.Send(newOrder);
            }
            catch (SessionNotFound ex)
            {
                Console.WriteLine("Session not found: " + ex.Message);
            }
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {

            var msgType = message.Header.GetField(Tags.MsgType);            
            if (msgType == "A"){
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
