using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;

namespace MohatechMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICommentBusiness _commentBusiness;
        public ProductController(ICommentBusiness commentBusiness)
        {
            _commentBusiness = commentBusiness;
        }

        public ActionResult ShowComment(int id)
        {
            return PartialView(_commentBusiness.Get().Where(c => c.ProductId == id));
        }

        public ActionResult CreateComment(int id)
        {
            return PartialView(new Comment()
            {
                ProductId = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                _commentBusiness.Insert(comment);
                _commentBusiness.Save();
                return PartialView("ShowComment", _commentBusiness.Get().Where(c => c.ProductId == comment.ProductId));
            }

            return PartialView(comment);
        }
    }
}