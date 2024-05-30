namespace Common.Entities
{
    public enum OrdType
    {
        MARKET = 1,
        LIMIT = 2,
        STOP_LOSS = 3,
        STOP_LIMIT = 4
    }

    public enum OrdStatus
    {
        NEW = 0,
        PARTIALLY_FILLED = 1,
        FILLED = 2,
        DONE_FOR_DAY = 3,
        CANCELED = 4,
        REPLACED = 5,
        PENDING_CANCEL = 6,
        STOPPED = 7,
        REJECTED = 8,
        SUSPENDED = 9,
        PENDING_NEW = 'A',
        CALCULATED = 'B',
        EXPIRED = 'C',
        ACCEPTED_FOR_BIDDING = 'D',
        PENDING_REPLACE = 'E',
        PREVIOUS_FINAL_STATE = 'Z',
    }

    public enum Side
    {
        BUY = 1, SELL = 2
    }

    public enum MsgType
    {
        HEARTBEAT = 0,
        TEST_REQUEST = 1,
        RESEND_REQUEST = 2,
        REJECT = 3,
        SEQUENCE_RESET = 4,
        LOGOUT = 5,
        EXECUTION_REPORT = 8,
        ORDER_CANCEL_REJECT = 9,
        LOGON = 'A',
        ORDER_SINGLE = 'D',
        ORDER_CANCEL_REQUEST = 'F',
        ORDER_CANCEL_REPLACE_REQUEST = 'G',
    }
}
