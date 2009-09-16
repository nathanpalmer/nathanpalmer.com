using System.Web.Security;
using NathanPalmer.com.Core.Services;

namespace NathanPalmer.com.Infrastructure.Services.Impl
{
    public class FormsAuthenticationService : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}