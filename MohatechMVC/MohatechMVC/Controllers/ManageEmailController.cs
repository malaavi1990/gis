using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MohatechMVC.Controllers
{
    public class ManageEmailController : Controller
    {
        public ActionResult ActiveUser()
        {
            return PartialView();
        }

        public ActionResult ForgotPassword()
        {
            return PartialView();
        }
    }
}