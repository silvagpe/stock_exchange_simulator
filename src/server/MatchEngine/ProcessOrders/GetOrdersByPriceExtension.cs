using System.Collections.Concurrent;
using Common.Entities;

namespace server.MatchEngine.ProcessOrders;

public static class GetOrdersByPriceExtension
{
    public static ConcurrentQueue<Order>? GetOrdersByPrice(
        this ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>> orders, 
        string symbol, decimal price)
        {
            var orderBySymbol =  orders.GetOrdersBySymbol(symbol);            
            if (orderBySymbol is null) { return null; }

            return orderBySymbol
                .Where(x => x.Key == price)
                .Select(x => x.Value)
                .FirstOrDefault();
        }
}