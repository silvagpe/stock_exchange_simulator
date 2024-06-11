﻿using Common.Entities;
using System.Collections.Concurrent;

namespace server.MatchEngine
{
    public class OrderBookService : IOrderBookService
    {
        private ILogger<OrderBookService> _logger;

        public OrderBookService(ILogger<OrderBookService> logger)
        {
            _logger = logger;
        }

        private ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>> buyOrders =
            new ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>>();
        private ConcurrentDictionary<string, decimal> buyOrdersMinPrice = new ConcurrentDictionary<string, decimal>();
        private ConcurrentDictionary<string, decimal> buyOrdersMaxPrice = new ConcurrentDictionary<string, decimal>();


        private ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>> sellOrders =
            new ConcurrentDictionary<string, ConcurrentDictionary<decimal, ConcurrentQueue<Order>>>();
        private ConcurrentDictionary<string, decimal> sellOrdersMinPrice = new ConcurrentDictionary<string, decimal>();
        private ConcurrentDictionary<string, decimal> sellOrdersMaxPrice = new ConcurrentDictionary<string, decimal>();

        public ConcurrentDictionary<decimal, ConcurrentQueue<Order>>? GetOrdersBySymbol(Side side, string symbol)
        {

            return side switch
            {
                Side.BUY =>
                    buyOrders.TryGetValue(symbol, out ConcurrentDictionary<decimal, ConcurrentQueue<Order>>? orderByPrice) ? orderByPrice : null,
                _ => sellOrders.TryGetValue(symbol, out ConcurrentDictionary<decimal, ConcurrentQueue<Order>>? orderByPrice) ? orderByPrice : null,
            };

        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                _logger.LogWarning("Order null");
                return;
            }

            if (ProcessOrder(order))
            {
                return;
            }

            AddToBookBuyerOder(order);
            AddToBookSellOder(order);
        }

        private void AddToBookBuyerOder(Order order)
        {
            if (order.Side != Side.BUY) return;

            SaveMinValue(buyOrdersMinPrice, order);
            SaveMaxValue(buyOrdersMaxPrice, order);

            if (buyOrders.TryGetValue(order.Symbol, out var ordersByPrice))
            {
                if (ordersByPrice.TryGetValue(order.Price, out var orders))
                {
                    orders.Enqueue(order);
                }
                else
                {
                    orders = new ConcurrentQueue<Order>();
                    orders.Enqueue(order);
                    ordersByPrice.TryAdd(order.Price, orders);
                }
            }
            else
            {
                var orders = new ConcurrentQueue<Order>();
                orders.Enqueue(order);
                ordersByPrice = new ConcurrentDictionary<decimal, ConcurrentQueue<Order>>();
                ordersByPrice.TryAdd(order.Price, orders);
                buyOrders.TryAdd(order.Symbol, ordersByPrice);
            }
        }

        private void AddToBookSellOder(Order order)
        {
            if (order.Side != Side.SELL) return;

            SaveMinValue(sellOrdersMinPrice, order);
            SaveMaxValue(sellOrdersMaxPrice, order);

            if (sellOrders.TryGetValue(order.Symbol, out var ordersByPrice))
            {
                if (ordersByPrice.TryGetValue(order.Price, out var orders))
                {
                    orders.Enqueue(order);
                }
                else
                {
                    orders = new ConcurrentQueue<Order>();
                    orders.Enqueue(order);
                    ordersByPrice.TryAdd(order.Price, orders);
                }
            }
            else
            {
                var orders = new ConcurrentQueue<Order>();
                orders.Enqueue(order);
                ordersByPrice = new ConcurrentDictionary<decimal, ConcurrentQueue<Order>>();
                ordersByPrice.TryAdd(order.Price, orders);
                sellOrders.TryAdd(order.Symbol, ordersByPrice);
            }
        }

        private bool ProcessOrder(Order order)
        {
            bool result;
            if (order.Side == Side.BUY)
            {
                if (sellOrders.Count == 0) { return false; }
                result = ProcessBuyOrders(order);
            }
            else
            {
                if (buyOrders.Count == 0) { return false; }
                result = ProcessSellOrders(order);
            }

            return result;
        }

        private bool ProcessBuyOrders(Order order)
        {


            return false;
        }
        private bool ProcessSellOrders(Order order) { return false; }

        private void SaveMaxValue(ConcurrentDictionary<string, decimal> dictionary, Order order)
        {
            if (dictionary.TryGetValue(order.Symbol, out var maxPrice))
            {
                if (order.Price > maxPrice)
                {
                    dictionary[order.Symbol] = order.Price;
                }
            }
            else
            {
                dictionary.TryAdd(order.Symbol, order.Price);
            }
        }

        private void SaveMinValue(ConcurrentDictionary<string, decimal> dictionay, Order order)
        {
            if (dictionay.TryGetValue(order.Symbol, out var minPrice))
            {
                if (order.Price < minPrice)
                {
                    dictionay[order.Symbol] = order.Price;
                }
            }
            else
            {
                dictionay.TryAdd(order.Symbol, order.Price);
            }
        }
    }
}
