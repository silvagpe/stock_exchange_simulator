
using Common.Entities;

namespace UnitTest.Server;


public class TestFixture
{
    public static Order CreateNewOrderSingle(string orderId, string account, string clOrdId, decimal quantity, decimal price, Side side, string symbol)
    {
        return new Order
        {
            Account = account,
            ClOrdId = clOrdId,
            CumQty = quantity,
            LastQty = quantity,
            LeavesQty = quantity,
            OrderId = orderId,
            OrderQty = quantity,
            OrdStatus = OrdStatus.NEW,
            OrdType = OrdType.LIMIT,
            Price = price,
            SessionId = "1",
            Side = side,
            Symbol = symbol,
            TransactionTime = DateTime.UtcNow
        };
    }
}
