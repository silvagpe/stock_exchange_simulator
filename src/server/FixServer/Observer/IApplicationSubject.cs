using QuickFix;

namespace server.FixServer.Observer
{
    public interface IApplicationSubject
    {
        event EventHandler<(SessionID, Message)>? FromAdminNotification;
        event EventHandler<(SessionID, Message)>? FromAppNotification;
        event EventHandler<SessionID>? OnCreateNotification;

        void FromAdmin(Message message, SessionID sessionID);
        void FromApp(Message message, SessionID sessionID);
        void OnCreate(SessionID sessionID);
    }
}