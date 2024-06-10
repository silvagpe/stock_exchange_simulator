namespace Common.Entities
{
    public class Order
    {
        public string ClOrdId { get; set; }
        public string OrderId { get; set; }
        public string Account { get; set; }
        public string Symbol { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal OrderQty { get; set; }
        public decimal LastQty { get; set; }
        public decimal LeavesQty { get; set; }
        public decimal CumQty { get; set; }
        public decimal Price { get; set; }
        public Side Side { get; set; }
        public OrdType OrdType { get; set; }
        public OrdStatus OrdStatus { get; set; }
        public string SessionId { get; set; }
    }
}
