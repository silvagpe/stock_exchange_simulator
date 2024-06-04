using QuickFix;
using server.MatchEngine;

namespace UnitTest.Server.MatchEngineTests;

public class BookServiceTests
{
    [Fact]
    public void BookServiceShouldAddOrderOnMemory(){

        var bookService = new BookService();

        var message = new Message();

        bookService.AddOrder(message);
        var order =  bookService.GetByClOrdId("123");

        Assert.NotNull(order);
    }
}