using QuickFix;

namespace server.MatchEngine;

public interface IBookService
{
    void AddOrder(Message message); 
}