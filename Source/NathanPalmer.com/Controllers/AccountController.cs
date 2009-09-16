using System;
using System.Globalization;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using NathanPalmer.com.Core.Services;
using NathanPalmer.com.Infrastructure.Services.Impl;

namespace NathanPalmer.com.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private static readonly OpenIdRelyingParty openID = new OpenIdRelyingParty();

        // This constructor is used by the MVC framework to instantiate the controller using
        // the default forms authentication and membership providers.
        public AccountController()
            : this(null, null)
        {
        }

        // This constructor is not used by the MVC framework but is instead provided for ease
        // of unit testing this type. See the comments at the end of this file for more
        // information.
        public AccountController(IFormsAuthentication formsAuth, IMembershipService service)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationService();
            MembershipService = service ?? new AccountMembershipService();
        }

        public IFormsAuthentication FormsAuth
        {
            get;
            private set;
        }

        public IMembershipService MembershipService
        {
            get;
            private set;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult Authenticate(string OpenIDIdentifier, bool? RememberMe, string ReturnUrl)
        {
            //if (!ValidateLogOn(userName, password))
            //{
            //    return View();
            //}

            var response = openID.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(OpenIDIdentifier, out id))
                {
                    try
                    {
                        return openID.CreateRequest(OpenIDIdentifier).RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("LogOn");
                    }
                }

                ViewData["Message"] = "Invalid identifier";
                return View("LogOn");
            }

            // Stage 3: OpenID Provider sending assertion response
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    if (!MembershipService.ValidateUser(response.ClaimedIdentifier, ""))
                    {
                        ModelState.AddModelError("_FORM", "Your user is not allowed to login.");
                        return View("LogOn");
                    }

                    Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
                    FormsAuth.SignIn(response.ClaimedIdentifier, (RememberMe) ?? false);
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                    
                case AuthenticationStatus.Canceled:
                    ViewData["Message"] = "Canceled at provider";
                    return View("LogOn");
                case AuthenticationStatus.Failed:
                    ViewData["Message"] = response.Exception.Message;
                    return View("LogOn");
            }
            return new EmptyResult();
        }

        public ActionResult LogOff()
        {
            FormsAuth.SignOut();
            return RedirectToAction("Index", "Home");
        }              
    }
}
