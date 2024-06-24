using System.Collections.Concurrent;
using Common.Entities;

namespace server.MatchEngine.ProcessOrders;

public class ProcessOrderService
{
    public void Process(Order customerOder, ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>> orders){

        if (customerOder is null) return;

                

        // customerOder.Side
    }
}