using Common.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using server.MatchEngine;

namespace UnitTest.Server.MatchEngineTests;

public class OrderBookServiceTests
{
    [Fact]
    public void ShouldAddOrderOnMemory()
    {

        var log = new Mock<ILogger<OrderBookService>>();
        var bookService = new OrderBookService(log.Object);

        Order sellOrder = new Order
        {
            Account = "101",
            ClOrdId = "CL01",
            CumQty = 10,
            LastQty = 10,
            LeavesQty = 10,
            OrderId = "1",
            OrderQty = 10,
            OrdStatus = OrdStatus.NEW,
            OrdType = OrdType.LIMIT,
            Price = 10M,
            SessionId = "1",
            Side = Side.SELL,
            Symbol = "PETR4",
            TransactionTime = DateTime.UtcNow
        };
        bookService.AddOrder(sellOrder);
        Order sellOrder2 = new Order
        {
            Account = "101",
            ClOrdId = "CL02",
            CumQty = 10,
            LastQty = 10,
            LeavesQty = 10,
            OrderId = "2",
            OrderQty = 10,
            OrdStatus = OrdStatus.NEW,
            OrdType = OrdType.LIMIT,
            Price = 10M,
            SessionId = "1",
            Side = Side.SELL,
            Symbol = "PETR4",
            TransactionTime = DateTime.UtcNow
        };
        bookService.AddOrder(sellOrder2);

        var orderByPrice = bookService.GetOrdersBySymbol(Side.SELL, "PETR4");
        Assert.NotNull(orderByPrice);
        var result = orderByPrice
            .Select(x => x.Value.Where(v => v.OrderId == sellOrder.OrderId))
            .Select(x => x.FirstOrDefault(x => x.OrderId == sellOrder.OrderId))
            .FirstOrDefault(x => x.OrderId == sellOrder.OrderId);

        Assert.Equal(sellOrder.OrderId, result.OrderId);

    }
}