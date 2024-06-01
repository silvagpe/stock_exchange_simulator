using client.Controllers.Inputs;
using client.Initiator;
using Microsoft.AspNetCore.Mvc;
using QuickFix;
using QuickFix.Fields;

namespace client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixAppController : ControllerBase
    {

        private readonly ILogger<FixAppController> _logger;
        private readonly IFixApplicationFacede _fixApplicationFacede;

        public FixAppController(ILogger<FixAppController> logger, IFixApplicationFacede fixApplicationFacede)
        {
            _logger = logger;
            _fixApplicationFacede = fixApplicationFacede;
        }

        [HttpGet]
        [Route("session-is-loggedon")]
        public bool Get()
        {
            return _fixApplicationFacede.SessionIsLoggedOn();
        }

        [HttpPost]
        [Route("newOrderSingle")]
        public bool NewOrderSingle(NewOrderSingleInput input)
        {
            Message newOrder = new Message();
            newOrder.Header.SetField(new QuickFix.Fields.MsgType("D"));
            newOrder.SetField(new ClOrdID(input.ClOrdId));
            newOrder.SetField(new Symbol(input.Symbol));
            newOrder.SetField(new QuickFix.Fields.Side(input.Side));
            newOrder.SetField(new TransactTime(DateTime.UtcNow));
            newOrder.SetField(new QuickFix.Fields.OrdType(input.OrdType));
            newOrder.SetField(new OrderQty(input.Quantity));
            newOrder.SetField(new Price(input.Price));

            return _fixApplicationFacede.SendFixMessage(newOrder);
        }
    }
}
