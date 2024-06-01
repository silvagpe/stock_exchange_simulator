using QuickFix;
using QuickFix.Fields;

namespace client.Initiator
{
    public class FixApplicationFacede : IFixApplicationFacede
    {
        private readonly ILogger<FixApplicationFacede> _logger;
        private readonly IApplication _application;
        private readonly Session _session;

        public FixApplicationFacede(ILogger<FixApplicationFacede> logger, IApplication application)
        {
            _logger = logger;
            _application = application;
            _session = ((IGetFixSession)application).Session;
        }

        public bool SessionIsLoggedOn()
        {
            return _session.IsLoggedOn;
        }
        public bool SendFixMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(_session, $"Session is null {nameof(_session)}");
            ArgumentNullException.ThrowIfNull(message, $"Message is null {nameof(message)}");

            try
            {
                return _session.Send(message);
            }
            catch (SessionNotFound ex)
            {
                _logger.LogError("Session not found: " + ex.Message);
                return false;
            }
        }

        public bool TestConnection()
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
                return _session.Send(newOrder);
            }
            catch (SessionNotFound ex)
            {
                _logger.LogError("Session not found: " + ex.Message);
                return false;
            }
        }

    }
}
