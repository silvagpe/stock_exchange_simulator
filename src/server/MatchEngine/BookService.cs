using System.Collections.Concurrent;
using Common.Entities;
using QuickFix;
using QuickFix.Fields;

namespace server.MatchEngine;

public class BookService : IBookService
{
    public ConcurrentDictionary<string, Order> BuyOrders = new ConcurrentDictionary<string, Order>();
    public ConcurrentDictionary<string, Order> SellOrders = new ConcurrentDictionary<string, Order>();

    public BookService()
    {
    }

    public void AddOrder(Message message)
    {
        var side = message.GetChar(Tags.Side);
        var clOrdId = message.GetString(Tags.ClOrdID);
        // switch (side)
        // {
        //     case Side.BUY: BuyOrders.TryAdd(clOrdId,)
        //     default:
        // }

    }

    public Order? GetByClOrdId(string clOrdId)
    {

        Order? order;
        if (BuyOrders.TryGetValue(clOrdId, out order))
        {
            return order;
        }
        if (SellOrders.TryGetValue(clOrdId, out order))
        {
            return order;
        }

        return null;
    }
}
