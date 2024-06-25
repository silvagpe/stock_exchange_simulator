using System.Collections.Concurrent;
using Common.Entities;

namespace server.MatchEngine.ProcessOrders;

public class ProcessOrderService
{
    public void ProcessLimitOrders(Order customerOder, ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>> counterpartOrders){

        if (customerOder is null) return;
        if (customerOder.OrdType != OrdType.LIMIT) return;

        var price = customerOder.Price;
        var symbol = customerOder.Symbol;
        var orders = counterpartOrders.GetOrdersByPrice(symbol ,price);
        if (orders is null) return;
                

        // customerOder.Side
    }
}