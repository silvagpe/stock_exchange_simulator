using System.Collections.Concurrent;
using Common.Entities;

namespace server.MatchEngine.ProcessOrders;

public static class GetOrderBySymbolExtension
{
    public static ConcurrentDictionary<decimal, ConcurrentQueue<Order>>? GetOrdersBySymbol(
        this ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>> orders, string symbol)
    {
        if (string.IsNullOrEmpty(symbol)) return null;

        return orders.TryGetValue(symbol, out ConcurrentDictionary<decimal, ConcurrentQueue<Order>>? orderByPrice) ? orderByPrice : null;
    }
}