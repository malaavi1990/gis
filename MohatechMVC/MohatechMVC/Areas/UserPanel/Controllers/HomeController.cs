using System.Web.Mvc;
using System.Web.Security;
using MohatechBusiness.Classes;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechViewModel;

namespace MohatechMVC.Areas.UserPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        public HomeController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public ActionResult Index()
        {
            User user = _userBusiness.GetByEmail(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(int id, ChangePasswordViewModel changePassword)
        {
            if (ModelState.IsValid)
            {
                string hashOldPassword =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(changePassword.OldPassword, "MD5");
                User user = _userBusiness.GetById(id);
                if (user.Password == hashOldPassword)
                {
                    string hashNewPassword =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(changePassword.Password, "MD5");
                    user.Password = hashNewPassword;
                    _userBusiness.Update(user);
                    _userBusiness.Save();

                    TempData["Title"] = "تغییر کلمه عبور";
                    TempData["Message"] = "کلمه عبور شما با موفقیت تغییر کرد";
                    TempData["Class"] = "alert alert-success";
                    return View("Notification");

                }
                else
                {
                    ViewBag.Message = "کلمه عبور فعلی شما صحیح نیست";
                    ViewBag.Class = "alert alert-danger";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            User user = _userBusiness.GetById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(int id, User user)
        {
            if (ModelState.IsValid)
            {
                _userBusiness.Update(user);
                _userBusiness.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}