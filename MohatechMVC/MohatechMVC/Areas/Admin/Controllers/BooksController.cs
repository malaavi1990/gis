using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechUtility;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookBusiness _bookBusiness;
        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        public ActionResult Index()
        {
            return View(_bookBusiness.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,Description,Text,Visit,ImageName")] Book book
            , HttpPostedFileBase imageBook)
        {
            if (ModelState.IsValid)
            {
                if (imageBook != null && imageBook.IsImage())
                {
                    book.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageBook.FileName);
                    imageBook.SaveAs(Server.MapPath("/Content/Image/Book/" + book.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Book/" + book.ImageName),
                        Server.MapPath("/Content/Image/Book/Thumbnail/" + book.ImageName));

                    book.CreateDate = DateTime.Now;
                    _bookBusiness.Insert(book);
                    _bookBusiness.Save();
                    return RedirectToAction("Index");
                }

                return View(book);
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = _bookBusiness.GetById(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,Description,Text,Visit,CreateDate,ImageName")] Book book
        , HttpPostedFileBase imageBook)
        {
            if (ModelState.IsValid)
            {
                if (imageBook != null && imageBook.IsImage())
                {
                    System.IO.File.Delete(Server.MapPath("/Content/Image/Book/" + book.ImageName));
                    System.IO.File.Delete(Server.MapPath("/Content/Image/Book/Thumbnail/" + book.ImageName));

                    book.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageBook.FileName);
                    imageBook.SaveAs(Server.MapPath("/Content/Image/Book/" + book.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Book/" + book.ImageName),
                        Server.MapPath("/Content/Image/Book/Thumbnail/" + book.ImageName));
                }

                _bookBusiness.Update(book);
                _bookBusiness.Save();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            Book book = _bookBusiness.GetById(id);
            System.IO.File.Delete(Server.MapPath("/Content/Image/Book/" + book.ImageName));
            System.IO.File.Delete(Server.MapPath("/Content/Image/Book/Thumbnail/" + book.ImageName));

            _bookBusiness.Delete(id);
            _bookBusiness.Save();
            return RedirectToAction("Index");
        }
    }
}
