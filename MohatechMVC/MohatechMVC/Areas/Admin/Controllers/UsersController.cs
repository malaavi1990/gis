using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using MohatechBusiness.Interfaces;
using MohatechDomain;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IRoleBusiness _roleBusiness;
        public UsersController(IUserBusiness userBusiness, IRoleBusiness roleBusiness)
        {
            _userBusiness = userBusiness;
            _roleBusiness = roleBusiness;
        }

        public ActionResult Index()
        {
            IEnumerable<User> users = _userBusiness.Get();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            User user = _userBusiness.GetById(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(_roleBusiness.Get(), "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Email,Password,UserName,FirstName,LastName,IsActive,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = _userBusiness.CheckEmail(user.Email);
                if (checkEmail == false)
                {
                    string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                    user.Password = hashPassword;
                    user.RegisterDate = DateTime.Now;
                    user.ActiveCode = Guid.NewGuid().ToString();
                    _userBusiness.Insert(user);
                    _userBusiness.Save();
                    return RedirectToAction("Index");
                }

                ViewBag.Message = "ایمیل وارد شده تکراری است";
                ViewBag.Class = "alert alert-danger";
                ViewBag.RoleId = new SelectList(_roleBusiness.Get(), "RoleId", "RoleName", user.RoleId);
                return View(user);
            }
            ViewBag.RoleId = new SelectList(_roleBusiness.Get(), "RoleId", "RoleName", user.RoleId);
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = _userBusiness.GetById(id);
            ViewBag.RoleId = new SelectList(_roleBusiness.Get(), "RoleId", "RoleName", user.RoleId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Email,Password,UserName,FirstName,LastName,IsActive,ActiveCode,RegisterDate,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                bool checkEmail = _userBusiness.CheckEmail(user.Email);
                if (checkEmail == false)
                {
                    string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                    _userBusiness.Update(user);
                    _userBusiness.Save();
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "ایمیل وارد شده تکراری است";
                ViewBag.Class = "alert alert-danger";
                ViewBag.RoleId = new SelectList(_roleBusiness.Get(), "RoleId", "RoleName", user.RoleId);
                return View(user);
            }
            ViewBag.RoleId = new SelectList(_roleBusiness.Get(), "RoleId", "RoleName", user.RoleId);
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = _userBusiness.GetById(id);
            _userBusiness.Delete(user);
            _userBusiness.Save();
            return RedirectToAction("Index");
        }

        public ActionResult RoleList()
        {
            IEnumerable<Role> roles = _roleBusiness.Get();
            return View(roles);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                bool checkRole = _roleBusiness.CheckRoleName(role.RoleName);
                if (checkRole == false)
                {
                    _roleBusiness.Insert(role);
                    _roleBusiness.Save();
                    return RedirectToAction("RoleList");
                }
                ViewBag.Message = "نقش کاربری وارد شده تکراری است";
                ViewBag.Class = "alert alert-danger";
                return View(role);
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditRole(int id)
        {
            Role role = _roleBusiness.GetById(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(Role role)
        {
            if (ModelState.IsValid)
            {
                bool checkRole = _roleBusiness.CheckRoleName(role.RoleName);
                if (checkRole == false)
                {
                    _roleBusiness.Update(role);
                    _roleBusiness.Save();
                    return RedirectToAction("RoleList");
                }
                ViewBag.Message = "نقش کاربری وارد شده تکراری است";
                ViewBag.Class = "alert alert-danger";
                return View(role);
            }
            return View(role);
        }

        public ActionResult DeleteRole(int id)
        {
            Role role = _roleBusiness.GetById(id);
            _roleBusiness.Delete(role);
            _roleBusiness.Save();
            return RedirectToAction("RoleList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
