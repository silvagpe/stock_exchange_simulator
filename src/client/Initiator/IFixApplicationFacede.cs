using QuickFix;

namespace client.Initiator
{
    public interface IFixApplicationFacede
    {
        bool SendFixMessage(Message message);
        bool SessionIsLoggedOn();
        bool TestConnection();
    }
}
