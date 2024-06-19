using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using server.MatchEngine;

namespace UnitTest.Server;

public class TestFixture
{
    private readonly AutoMocker _autoMocker;

    public TestFixture()
    {
        _autoMocker = new AutoMocker();   

        ConfigureOrderBookService();
    }

    private void ConfigureOrderBookService(){
        var log = new Mock<ILogger<OrderBookService>>();
        var bookService = new OrderBookService(log.Object);
        _autoMocker.Use<IOrderBookService>(bookService);
    }

    public T CreateInstance<T>() where T : class => _autoMocker.CreateInstance<T>();

    public Mock<T> GetMock<T>() where T : class => _autoMocker.GetMock<T>();

    public void Use<T>(T value) where T : class => _autoMocker.Use<T>(value);
}
