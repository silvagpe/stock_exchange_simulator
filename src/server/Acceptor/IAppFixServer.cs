using QuickFix;

namespace server.Acceptor
{
    public interface IAppFixServer
    {
        void FromAdmin(Message message, SessionID sessionID);
        void FromApp(Message message, SessionID sessionID);
        void OnCreate(SessionID sessionID);
        void OnLogon(SessionID sessionID);
        void OnLogout(SessionID sessionID);
        void ToAdmin(Message message, SessionID sessionID);
        void ToApp(Message message, SessionID sessionId);
    }
}