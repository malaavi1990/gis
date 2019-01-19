using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechUtility;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class SoftwaresController : Controller
    {
        private readonly ISoftwareBusiness _softwareBusiness;

        public SoftwaresController(ISoftwareBusiness softwareBusiness)
        {
            _softwareBusiness = softwareBusiness;
        }

        public ActionResult Index()
        {
            return View(_softwareBusiness.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoftwareId,Title,Description,Text,Visit,CreateDate,ImageName")] Software software
        , HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    software.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/Softwares/" + software.ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Content/Image/Softwares/" + software.ImageName),
                        Server.MapPath("/Content/Image/Softwares/Thumbnail/" + software.ImageName));

                    software.CreateDate = DateTime.Now;
                    software.Visit = 0;
                    _softwareBusiness.Insert(software);
                    _softwareBusiness.Save();
                    return RedirectToAction("Index");
                }

                ViewBag.NewsImage = true;
                return View(software);
            }

            return View(software);
        }

        public ActionResult Edit(int id)
        {
            Software software = _softwareBusiness.GetById(id);
            return View(software);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoftwareId,Title,Description,Text,Visit,CreateDate,ImageName")] Software software
            , HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    System.IO.File.Delete(Server.MapPath("/Content/Image/Softwares/" + software.ImageName));
                    System.IO.File.Delete(Server.MapPath("/Content/Image/Softwares/Thumbnail/" + software.ImageName));

                    software.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/Softwares/" + software.ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Content/Image/Softwares/" + software.ImageName),
                        Server.MapPath("/Content/Image/Softwares/Thumbnail/" + software.ImageName));
                }

                _softwareBusiness.Update(software);
                _softwareBusiness.Save();
                return RedirectToAction("Index");
            }
            return View(software);
        }

        public ActionResult Delete(int id)
        {
            Software software = _softwareBusiness.GetById(id);
            System.IO.File.Delete(Server.MapPath("/Content/Image/Softwares/" + software.ImageName));
            System.IO.File.Delete(Server.MapPath("/Content/Image/Softwares/Thumbnail/" + software.ImageName));

            _softwareBusiness.Delete(id);
            _softwareBusiness.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
