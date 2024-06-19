using System.Collections.Concurrent;
using Common.Entities;

namespace server.MatchEngine
{
    public interface IOrderBookService
    {
        void AddOrder(Order order);
        ConcurrentDictionary<decimal, ConcurrentQueue<Order>>? GetOrdersBySymbol(Side side, string symbol);
    }
}