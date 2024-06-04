using Common.Entities;
using QuickFix;
using QuickFix.Fields;

namespace common.Entities.Mappers;

public class OrderMapper
{
    public Order Map(Message message){
        var order = new Order();

        order.ClOrdId = message.GetStringIfExist(Tags.ClOrdID);
        order.OrderId = message.GetStringIfExist(Tags.OrderID);
        order.Account = message.GetString(Tags.Account);
        order.Symbol = message.GetString(Tags.Symbol);
        order.TransactionTime = message.GetDateTime(Tags.TransactTime);
        order.OrderQty = message.GetDecimalIfExist(Tags.OrderQty);
        order.LastQty = message.GetDecimalIfExist(Tags.LastQty);
        order.LeavesQty = message.GetDecimalIfExist(Tags.LeavesQty);
        order.CumQty = message.GetDecimalIfExist(Tags.CumQty);
        order.Price = message.GetDecimalIfExist(Tags.Price);
        order.Side = message.GetSide();
        order.OrdType = message.GetOrderType();
        order.OrdStatus = message.GetOrdStatus();        
        return order;
    }
}
