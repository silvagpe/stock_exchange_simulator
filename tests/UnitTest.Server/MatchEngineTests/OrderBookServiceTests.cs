using Common.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using server.MatchEngine;

namespace UnitTest.Server.MatchEngineTests;

public class OrderBookServiceTests
{
    private readonly TestFixture _fixture;

    public OrderBookServiceTests()
    {
        _fixture = new TestFixture();
    }

    private IEnumerable<Order> PrepareOrdersToTest(IOrderBookService bookService, string symbol)
    {
        var listOrder = new List<Order>();
        Order sellOrder1 = TestFixture.CreateNewOrderSingle("1", "01", "cl01", 10, 10M, Side.SELL, symbol);
        bookService.AddOrder(sellOrder1);
        listOrder.Add(sellOrder1);

        Order sellOrder2 = TestFixture.CreateNewOrderSingle("2", "02", "cl02", 10, 10M, Side.SELL, symbol);
        bookService.AddOrder(sellOrder2);
        listOrder.Add(sellOrder2);

        Order sellOrder3 = TestFixture.CreateNewOrderSingle("3", "03", "cl03", 10, 11M, Side.SELL, symbol);
        bookService.AddOrder(sellOrder3);
        listOrder.Add(sellOrder3);

        return listOrder;
    }

    [Fact]
    public void ShouldAddOrderOnMemoryAndGetOrdersBySymbol()
    {
        IOrderBookService bookService = _fixture.CreateInstance<OrderBookService>();

        string symbol = "PETR4";
        var listOrders = PrepareOrdersToTest(bookService, symbol);

        var  sellOrder1 = listOrders.FirstOrDefault();
        var orderByPrice = bookService.GetOrdersBySymbol(Side.SELL, symbol);
        Assert.NotNull(orderByPrice);
        var result = orderByPrice
            .Select(x => x.Value.Where(v => v.OrderId == sellOrder1?.OrderId))
            .Select(x => x.FirstOrDefault(x => x.OrderId == sellOrder1?.OrderId))
            .FirstOrDefault(x => x?.OrderId == sellOrder1?.OrderId);

        Assert.Equal(sellOrder1?.OrderId, result?.OrderId);
    }

    [Fact]
    public void ShouldAddOrderOnMemoryAndGetOrdersByPrice()
    {
        IOrderBookService bookService = _fixture.CreateInstance<OrderBookService>();

        string symbol = "PETR4";
        _ = PrepareOrdersToTest(bookService, symbol);

        var ordersWithPrice10 = bookService.GetOrdersByPrice(Side.SELL, symbol, 10M);
        Assert.NotNull(ordersWithPrice10);
        ordersWithPrice10.Count().Should().Be(2);

        var ordersWithPrice11 = bookService.GetOrdersByPrice(Side.SELL, symbol, 11M);
        Assert.NotNull(ordersWithPrice11);
        ordersWithPrice11.Count().Should().Be(1);
    }
}