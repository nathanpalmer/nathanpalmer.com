namespace NathanPalmer.com.Core.Services
{
    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}