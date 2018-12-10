using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechUtility;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsBusiness _newsBusiness;

        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        public ActionResult Index()
        {
            return View(_newsBusiness.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,Title,Description,Text,ImageName,Visit,CreateDate")] News news, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    news.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/News/" + news.ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Content/Image/News/" + news.ImageName),
                        Server.MapPath("/Content/Image/News/Thumbnail/" + news.ImageName));

                    news.CreateDate = DateTime.Now;
                    news.Visit = 0;
                    _newsBusiness.Insert(news);
                    _newsBusiness.Save();
                    return RedirectToAction("Index");
                }

                ViewBag.NewsImage = true;
                return View(news);
            }

            return View(news);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            News news = _newsBusiness.GetById(id);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,Title,Description,Text,ImageName,Visit,CreateDate")] News news, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    news.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/News/" + news.ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Content/Image/News/" + news.ImageName),
                        Server.MapPath("/Content/Image/News/Thumbnail/" + news.ImageName));
                }
                news.CreateDate = DateTime.Now;
                news.Visit = 0;
                _newsBusiness.Update(news);
                _newsBusiness.Save();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        public ActionResult Delete(int id)
        {
            var news = _newsBusiness.GetById(id);
            System.IO.File.Delete(Server.MapPath("/Conrent/Image/News/" + news.ImageName));
            System.IO.File.Delete(Server.MapPath("/Conrent/Image/News/Thumbnail/" + news.ImageName));

            _newsBusiness.Delete(id);
            _newsBusiness.Save();
            return RedirectToAction("Index");
        }
    }
}
