
namespace Common.Entities
{
    public static class OrderExtension{
        public static char GetFixMsgType(this Order order){

            return order.Side switch{
                Side.BUY => QuickFix.Fields.Side.BUY,
                _ => QuickFix.Fields.Side.SELL
            };
        }

        public static char GetFixOrdType(this Order order){

            return order.OrdType switch{
                OrdType.MARKET => QuickFix.Fields.OrdType.MARKET,
                OrdType.LIMIT => QuickFix.Fields.OrdType.LIMIT,
                OrdType.STOP_LOSS => QuickFix.Fields.OrdType.STOP,
                OrdType.STOP_LIMIT => QuickFix.Fields.OrdType.STOP_LIMIT
                // _ => QuickFix.Fields.OrdType.
            };
        }
    }
}