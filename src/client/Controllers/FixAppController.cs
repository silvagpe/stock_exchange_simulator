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
            if (input.Side.HasValue)
                newOrder.SetField(new QuickFix.Fields.Side(input.Side.Value));

            newOrder.SetField(new TransactTime(DateTime.UtcNow));
            if (input.OrdType.HasValue)
                newOrder.SetField(new QuickFix.Fields.OrdType(input.OrdType.Value));

            if (input.Quantity.HasValue)
                newOrder.SetField(new OrderQty(input.Quantity.Value));
            
            if (input.Price.HasValue)
                newOrder.SetField(new Price(input.Price.Value));

            return _fixApplicationFacede.SendFixMessage(newOrder);
        }
    }
}
