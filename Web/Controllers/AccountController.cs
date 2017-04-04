using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Web.Filters;
using Web.Models;
using Web.Helper;
using Web.Service;

namespace Web.Controllers
{
    public class AccountController : Web.Helper.AdminBaseController
    {
        private AccountService accountService;

        public AccountController()
        {
            accountService = new AccountService(CommonService);
        }

        [AllowAnonymous]
        public ActionResult login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.CompanyList = this.CommonService.GetAllCompanies().Select(P => new SelectListItem() { Text = P.Code, Value = P.ID }).ToList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(LoginModel model)
        {
            this.ChangeComapny(model.Company,"");
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return loginSuccess(model);
            }
            ModelState.AddModelError("error", "The user name or password provided is incorrect.");
            ViewBag.CompanyList = this.CommonService.GetAllCompanies().Select(P => new SelectListItem() { Text = P.Code, Value = P.ID }).ToList();
            return View(model);

        }

        public ActionResult loginSuccess(LoginModel model)
        {
            Web.Models.UserLogin _userLogin = null;
            if (User != null)
            {
                _userLogin = accountService.LoginUser(model.UserName, model.Password, model.Company);
                if (_userLogin != null)
                {
                    Session[Common.SessionKey.LOGGED_USER.ToKey()] = _userLogin;
                }
            }
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        public ActionResult logoff()
        {
            Session[Common.SessionKey.LOGGED_USER.ToKey()] = null;
            Session.Clear();
            Session.Abandon();
            WebSecurity.Logout();
            return RedirectToAction("login", "account");
        }

        [AllowAnonymous]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                        new
                        {
                            Password = model.Password,
                            ScreenName = model.ScreenName,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedOn = DateTime.UtcNow,
                            TransactionNo = Guid.NewGuid(),
                            IsActive = true
                        });
                    System.Web.Security.Roles.AddUserToRole(model.UserName, Web.Helper.Common.ApplicationRole.CasualUser.ToString());
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("index", "home");
                }
                catch (MembershipCreateUserException e)
                {
                    //ModelState.AddModelError("UserName", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult manage()
        {
            return View(new ChangePasswordModel());
        }

        public ActionResult changePassword(string currentPassword, string newPassword)
        {
            accountService.SetCompanyContext(this.Company);
            var success = accountService.ChangePassword(LoggedUser.UserName, currentPassword, newPassword);
            if (success)
            {
                return new JsonNetResult("Password changed successfully");
            }
            else
            {
                return new JsonNetResult("Incorrect old password.");
            }
        }

        public ActionResult generateResetPasswordLink()
        {
            //WebSecurity.GeneratePasswordResetToken(User.Identity.Name);
            return View("500");
        }
    }
}
