using QuickFix;

namespace client.Initiator
{
    public interface IFixApplicationFacede
    {
        Session Session { get; }

        bool SendFixMessage(Message message);
        bool SessionIsLoggedOn();
        bool TestConnection();
    }
}
