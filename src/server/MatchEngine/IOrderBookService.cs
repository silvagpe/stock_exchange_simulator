using Common.Entities;

namespace server.MatchEngine
{
    public interface IOrderBookService
    {
        void AddOrder(Order order);
    }
}