using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MohatechDAL.UnitOfWork;

namespace APITest.Controllers
{
    public class HomeController : Controller
    {
        DataContext db=new DataContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var q = db.Roles.FirstOrDefault();
            return View(q);
        }
    }
}
