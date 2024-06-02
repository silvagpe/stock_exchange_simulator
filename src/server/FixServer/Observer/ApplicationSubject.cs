using QuickFix;

namespace server.FixServer.Observer
{
    public class ApplicationSubject : IApplicationSubject
    {
        public event EventHandler<(SessionID, Message)>? FromAdminNotification;
        public event EventHandler<(SessionID, Message)>? FromAppNotification;
        public event EventHandler<SessionID>? OnCreateNotification;

        public void FromAdmin(Message message, SessionID sessionID)
        {
            FromAdminNotification?.Invoke(this, (sessionID, message));
        }

        public void FromApp(Message message, SessionID sessionID)
        {
            FromAppNotification?.Invoke(this, (sessionID, message));
        }

        public void OnCreate(SessionID sessionID)
        {
            OnCreateNotification?.Invoke(this, sessionID);
        }
    }
}
