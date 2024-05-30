namespace client.Controllers.Inputs
{
    public class NewOrderSingleInput
    {
        public string ClOrdId { get; set; }        
        public string Account { get; set; }
        public string Symbol { get; set; }                
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public char Side { get; set; }
        public char OrdType { get; set; }    
    }
}