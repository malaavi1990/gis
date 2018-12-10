using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechUtility;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class SlidersController : Controller
    {
        private readonly ISliderBusiness _sliderBusiness;

        public SlidersController(ISliderBusiness sliderBusiness)
        {
            _sliderBusiness = sliderBusiness;
        }

        public ActionResult Index()
        {
            return View(_sliderBusiness.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,Title,ImageName,Sort")]
            Slider slider, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    slider.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/Slider/" + slider.ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Content/Image/Slider/" + slider.ImageName),
                        Server.MapPath("/Content/Image/Slider/Thumbnail/" + slider.ImageName));

                    _sliderBusiness.Insert(slider);
                    _sliderBusiness.Save();
                    return RedirectToAction("Index");
                }

                ViewBag.SliderImage = true;
                return View(slider);
            }

            return View(slider);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Slider slider = _sliderBusiness.GetById(id);
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,Title,ImageName,Sort")]
            Slider slider, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    System.IO.File.Delete(Server.MapPath("/Content/Image/Slider/" + slider.ImageName));
                    System.IO.File.Delete(Server.MapPath("/Content/Image/Slider/Thumbnail/" + slider.ImageName));

                    slider.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/Slider/" + slider.ImageName));
                    ImageResizer imageResizer = new ImageResizer();
                    imageResizer.Resize(Server.MapPath("/Content/Image/Slider/" + slider.ImageName),
                        Server.MapPath("/Content/Image/Slider/Thumbnail/" + slider.ImageName));
                }
                _sliderBusiness.Update(slider);
                _sliderBusiness.Save();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        public ActionResult Delete(int id)
        {
            var slider = _sliderBusiness.GetById(id);
            System.IO.File.Delete(Server.MapPath("/Content/Image/Slider/" + slider.ImageName));
            System.IO.File.Delete(Server.MapPath("/Content/Image/Slider/Thumbnail/" + slider.ImageName));

            _sliderBusiness.Delete(id);
            _sliderBusiness.Save();
            return RedirectToAction("Index");
        }
    }
}

