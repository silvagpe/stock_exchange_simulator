using Common.Entities;
using QuickFix;
using QuickFix.Fields;

namespace common.Entities.Mappers;

public static class FixMessageExtensions
{
    public static string GetStringIfExist(this Message message, int tag)
    {
        if (!message.IsSetField(tag))
        {
            return;
        }
        return message.GetString(tag);
    }

    public static decimal GetDecimalIfExist(this Message message, int tag)
    {
        if (!message.IsSetField(tag))
        {
            return;
        }
        return message.GetDecimal(tag);
    }

    public static Common.Entities.Side GetSide(this Message message)
    {
        if (!message.IsSetField(tag))
        {
            return;
        }

        var side = message.GetChar(Tags.Side);

        return site switch
        {
            "1" => Common.Entities.Side.BUY,
            "2" => Common.Entities.Side.SELL,
            _ => throw new ArgumentException("Side invalid")
        };
    }

    public static Common.Entities.OrdType GetOrderType(this Message message)
    {
        if (!message.IsSetField(tag))
        {
            return;
        }

        var ordType = message.GetChar(Tags.OrdType);

        return ordType switch
        {
            "1" => Common.Entities.OrdType.MARKET,
            "2" => Common.Entities.OrdType.LIMIT,
            "3" => Common.Entities.OrdType.STOP_LOSS,
            "4" => Common.Entities.OrdType.STOP_LIMIT,
            _ => throw new ArgumentException("OrdType invalid")
        };
    }

    public static Common.Entities.OrdStatus GetOrdStatus(this Message message)
    {
        if (!message.IsSetField(tag))
        {
            return;
        }

        var ordStatus = message.GetChar(Tags.OrdStatus);

        return ordStatus switch
        {
            "0" => Common.Entities.OrdStatus.NEW,
            "1" => Common.Entities.OrdStatus.PARTIALLY_FILLED,
            "2" => Common.Entities.OrdStatus.FILLED,
            "3" => Common.Entities.OrdStatus.DONE_FOR_DAY,
            "4" => Common.Entities.OrdStatus.CANCELED,
            "5" => Common.Entities.OrdStatus.REPLACED,
            "6" => Common.Entities.OrdStatus.PENDING_CANCEL,
            "7" => Common.Entities.OrdStatus.STOPPED,
            "8" => Common.Entities.OrdStatus.REJECTED,
            "9" => Common.Entities.OrdStatus.SUSPENDED,
            "A" => Common.Entities.OrdStatus.PENDING_NEW,
            "B" => Common.Entities.OrdStatus.CALCULATED,
            "C" => Common.Entities.OrdStatus.EXPIRED,
            "D" => Common.Entities.OrdStatus.ACCEPTED_FOR_BIDDING,
            "E" => Common.Entities.OrdStatus.PENDING_REPLACE,
            "Z" => Common.Entities.OrdStatus.PREVIOUS_FINAL_STATE,
            _ => throw new ArgumentException("OrdType invalid")
        };
    }    
}