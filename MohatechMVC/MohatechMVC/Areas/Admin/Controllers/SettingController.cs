using System.Web.Mvc;
using MohatechBusiness.Classes;
using MohatechBusiness.Interfaces;
using MohatechDomain;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingBusiness _settingBusiness;
        public SettingController(ISettingBusiness settingBusiness)
        {
            _settingBusiness = settingBusiness;
        }

        public ActionResult Index()
        {
            Setting setting = _settingBusiness.Get();
            return View(setting);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            Setting setting = _settingBusiness.Get();
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Setting setting)
        {
            if (ModelState.IsValid)
            {
                _settingBusiness.Update(setting);
                _settingBusiness.Save();
                return RedirectToAction("Index");
            }
            return View(setting);
        }
    }
}