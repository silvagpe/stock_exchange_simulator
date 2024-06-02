using QuickFix;

namespace server.FixServer.SessionManager
{
    public interface ISessionManagerService
    {
        SessionID? GetSession(string name);
        void Start();
    }
}