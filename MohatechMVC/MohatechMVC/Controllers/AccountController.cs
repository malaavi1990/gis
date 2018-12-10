using System;
using System.Web.Mvc;
using System.Web.Security;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechMVC.Utilities;
using MohatechUtility;
using MohatechViewModel;

namespace MohatechMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        public AccountController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                bool checkEmail = _userBusiness.CheckEmail(register.Email.Trim().ToLower());
                if (checkEmail == false)
                {
                    User user = new User()
                    {
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Email = register.Email.Trim().ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                        ActiveCode = Guid.NewGuid().ToString(),
                        RegisterDate = DateTime.Now,
                        UserName = register.UserName,
                        IsActive = false,
                        RoleId = 1
                    };
                    _userBusiness.Insert(user);
                    _userBusiness.Save();

                    // Send Active Code To Email
                    string body = PartialToString.RenderPartialView("ManageEmail", "ActiveUser", user);
                    SendEmail.Send(user.Email, "ایمیل فعالسازی", body);
                    TempData["Title"] = "فعالسازی حساب کاربری";
                    TempData["Message"] = "برای فعالسازی حساب کاربری به ایمیل خود مراجعه کنید و بر روی لینک کلیک کنید";
                    TempData["Class"] = "alert alert-success";
                    return View("Notification");
                }
                else
                {
                    ViewBag.Message = "ایمیل وارد شده تکراری است";
                    ViewBag.Class = "alert alert-danger";
                    return View();
                }
            }
            return View();
        }

        public ActionResult ActiveUser(string id)
        {
            var user = _userBusiness.GetByActiveCode(id);
            if (user != null)
            {
                user.IsActive = true;
                user.ActiveCode = Guid.NewGuid().ToString();
                _userBusiness.Update(user);
                _userBusiness.Save();

                TempData["Title"] = "تکمیل ثبت نام";
                TempData["Message"] = "ثبت نام شما تکمیل شد";
                TempData["Class"] = "alert alert-success";
                return View("Notification");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "/UserPanel/Home")
        {
            if (ModelState.IsValid)
            {
                var user = _userBusiness.GetByEmail(login.Email);
                var hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                if (user != null && user.Password == hashPassword)
                {
                    if (user.IsActive == true)
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, login.RememberMe);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ViewBag.Message = "حساب کاربری شما فعال نیست";
                        ViewBag.Class = "alert alert-danger";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "نام کاربری یا کلمه عبور اشتباه است";
                    ViewBag.Class = "alert alert-danger";
                    return View(); ;
                }
            }
            return View();
        }

        [Route("LogOut")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpGet]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var user = _userBusiness.GetByEmail(forgot.Email);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        string body = PartialToString.RenderPartialView("ManageEmail", "ForgotPassword", user);
                        SendEmail.Send(user.Email, "ایمیل تغییر کلمه عبور", body);
                        TempData["Title"] = "تغییر کلمه عبور";
                        TempData["Message"] = "برای تغییر کلمه عبور به ایمیل خود مراجعه کنید و بر روی لینک کلیک کنید";
                        TempData["Class"] = "alert alert-success";
                        return View("Notification");
                    }
                    ViewBag.Message = "حساب کاربری شما فعال نیست";
                    ViewBag.Class = "alert alert-danger";
                    return View();
                }
                ViewBag.Message = "حساب کاربری موجود نیست";
                ViewBag.Class = "alert alert-danger";
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword(string id)
        {
            var user = _userBusiness.GetByActiveCode(id);
            if (user != null)
            {
                return View();
            }
            else
            {
                TempData["Title"] = "بازیابی کلمه عبور";
                TempData["Message"] = "درخواست جدید ثبت کنید";
                TempData["Class"] = "alert alert-danger";
                return View("Notification");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string id, ResetPasswordViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var user = _userBusiness.GetByActiveCode(id);
                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(reset.Password, "MD5");
                user.Password = hashPassword;
                user.ActiveCode = Guid.NewGuid().ToString();
                _userBusiness.Update(user);
                _userBusiness.Save();

                TempData["Title"] = "اتمام تغییر کلمه عبور";
                TempData["Message"] = "کلمه عبور شما با موفقیت تغییر کرد";
                TempData["Class"] = "alert alert-success";
                return View("Notification");
            }
            return View();
        }
    }
}