using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;

namespace MohatechMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderBusiness _sliderBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly INewsBusiness _newsBusiness;
        private readonly ISoftwareBusiness _softwareBusiness;
        private readonly IBookBusiness _bookBusiness;
        public HomeController(ISliderBusiness sliderBusiness,
            IProductBusiness productBusiness,
            INewsBusiness newsBusiness,
            ISoftwareBusiness softwareBusiness,
            IBookBusiness bookBusiness)
        {
            _sliderBusiness = sliderBusiness;
            _productBusiness = productBusiness;
            _newsBusiness = newsBusiness;
            _softwareBusiness = softwareBusiness;
            _bookBusiness = bookBusiness;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = _productBusiness.Get();
            return View(products);
        }

        public ActionResult Slider()
        {
            IEnumerable<Slider> sliders = _sliderBusiness.Get();
            return PartialView(sliders);
        }

        public ActionResult LearnProduct(int id)
        {
            ViewBag.OtherProduct = _productBusiness.Get().Take(4);
            Product product = _productBusiness.GetById(id);
            return View(product);
        }

        public ActionResult SoftwaresList()
        {
            IEnumerable<Software> softwares = _softwareBusiness.Get();
            return PartialView(softwares);
        }

        public ActionResult SoftwareDetails(int id)
        {
            ViewBag.OthetSoftware = _softwareBusiness.Get().Take(4);
            Software software = _softwareBusiness.GetById(id);
            return View(software);
        }

        public ActionResult BookList()
        {
            return PartialView(_bookBusiness.Get());
        }

        public ActionResult BookDetails(int id)
        {
            ViewBag.OtherBook = _bookBusiness.Get().Take(4);
            Book book = _bookBusiness.GetById(id);
            return View(book);
        }

        public ActionResult NewsList()
        {
            return PartialView(_newsBusiness.Get());
        }

        public ActionResult NewsDetails(int id)
        {
            ViewBag.OtherNews = _newsBusiness.Get().Take(4);
            News news = _newsBusiness.GetById(id);
            return View(news);
        }

        
    }
}