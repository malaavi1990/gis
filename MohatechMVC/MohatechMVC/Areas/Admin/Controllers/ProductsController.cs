using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MohatechBusiness.Interfaces;
using MohatechDomain;
using MohatechUtility;
using WebGrease.Css.Extensions;

namespace MohatechMVC.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductBusiness _productBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly IProductCategoryBusiness _productCategoryBusiness;
        private readonly ITagBusiness _tagBusiness;
        private readonly IGalleryBusiness _galleryBusiness;
        public ProductsController(IProductBusiness productBusiness,
            ICategoryBusiness categoryBusiness,
            IProductCategoryBusiness productCategoryBusiness,
            ITagBusiness tagBusiness,
            IGalleryBusiness galleryBusiness)
        {
            _productBusiness = productBusiness;
            _categoryBusiness = categoryBusiness;
            _productCategoryBusiness = productCategoryBusiness;
            _tagBusiness = tagBusiness;
            _galleryBusiness = galleryBusiness;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = _productBusiness.Get();
            return View(products);
        }

        public ActionResult CategoryList()
        {
            IEnumerable<Category> categories = _categoryBusiness.Get();
            return View(categories);
        }

        [HttpGet]
        public ActionResult CreateCategory(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Category category, int id)
        {
            if (ModelState.IsValid)
            {
                category.ParentId = id;
                _categoryBusiness.Insert(category);
                _categoryBusiness.Save();
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            Category category = _categoryBusiness.GetById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryBusiness.Update(category);
                _categoryBusiness.Save();
                return RedirectToAction("CategoryList");
            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categories = _categoryBusiness.Get();
            if (categories.Where(c => c.ParentId == id).Any())
            {
                var category = categories.Where(c => c.ParentId == id);
                foreach (var item in category)
                {
                    _categoryBusiness.Delete(item.CategoryId);
                }
            }
            _categoryBusiness.Delete(id);
            _categoryBusiness.Save();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryBusiness.Get();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Title,Description,Text,Visit,Price,ImageName,Sort")] Product product,
            List<int> selectedCategory, HttpPostedFileBase imageProduct, string tags)
        {
            if (ModelState.IsValid)
            {
                // Check Categories
                if (selectedCategory == null)
                {
                    ViewBag.Category = true;
                    ViewBag.Categories = _categoryBusiness.Get();
                    return View(product);
                }
                // Image
                product.ImageName = "user123456789.png";
                if (imageProduct != null && imageProduct.IsImage())
                {
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Content/Image/Product/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Product/" + product.ImageName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + product.ImageName));
                }

                _productBusiness.Insert(product);
                _productBusiness.Save();

                // Category
                foreach (var category in selectedCategory)
                {
                    _productCategoryBusiness.Insert(new ProductCategory()
                    {
                        CategoryId = category,
                        ProductId = product.ProductId
                    });
                }

                // Tags
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tagsList = tags.Split(',');
                    foreach (var tag in tagsList)
                    {
                        _tagBusiness.Insert(new Tag()
                        {
                            ProductId = product.ProductId,
                            TagName = tag.Trim()
                        });
                    }
                }
                _tagBusiness.Save();
                _productCategoryBusiness.Save();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryBusiness.Get();
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _productBusiness.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.SelectedCategory = product.ProductCategories.ToList();
            var tagsList = _tagBusiness.GetByProductId(id).Select(t => t.TagName);
            ViewBag.Tags = string.Join(",", tagsList);
            ViewBag.Categories = _categoryBusiness.Get();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Description,Text,Visit,Price,ImageName,Sort")] Product product,
            List<int> selectedCategory, HttpPostedFileBase imageProduct, string tags)
        {
            if (ModelState.IsValid)
            {
                // Check Categories
                if (selectedCategory == null)
                {
                    ViewBag.Category = true;
                    ViewBag.SelectedCategory = selectedCategory;
                    ViewBag.Tags = tags;
                    ViewBag.Categories = _categoryBusiness.Get();
                    return View(product);
                }
                // Image
                if (imageProduct != null && imageProduct.IsImage())
                {
                    if (product.ImageName != "user123456789.png")
                    {
                        System.IO.File.Delete(Server.MapPath("/Content/Image/Product/" + product.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Content/Image/Product/Thumbnail/" + product.ImageName));
                    }
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Content/Image/Product/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Content/Image/Product/" + product.ImageName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + product.ImageName));
                }

                _productBusiness.Update(product);
                _productBusiness.Save();

                // Category
                _productCategoryBusiness.GetByProductId(product.ProductId).ForEach(p => _productCategoryBusiness.Delete(p));
                foreach (var category in selectedCategory)
                {
                    _productCategoryBusiness.Insert(new ProductCategory()
                    {
                        CategoryId = category,
                        ProductId = product.ProductId
                    });
                }
                _productCategoryBusiness.Save();

                // Tags
                _tagBusiness.GetByProductId(product.ProductId).ForEach(t => _tagBusiness.Delete(t.TagId));
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tagsList = tags.Split(',');
                    foreach (var tag in tagsList)
                    {
                        _tagBusiness.Insert(new Tag()
                        {
                            ProductId = product.ProductId,
                            TagName = tag.Trim()
                        });
                    }
                }
                _tagBusiness.Save();

                return RedirectToAction("Index");
            }

            ViewBag.SelectedCategory = selectedCategory;
            ViewBag.Tags = tags;
            ViewBag.Categories = _categoryBusiness.Get();
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            _productBusiness.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Gallery(int id)
        {
            ViewBag.ProductName = _productBusiness.GetById(id).Title;
            ViewBag.Galleries = _galleryBusiness.GetByProductId(id);
            return View(new Gallery()
            {
                ProductId = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gallery(Gallery gallery, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    gallery.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/Image/Product/" + gallery.ImageName));
                    ImageResizer imgResizer = new ImageResizer();
                    imgResizer.Resize(Server.MapPath("/Content/Image/Product/" + gallery.ImageName),
                        Server.MapPath("/Content/Image/Product/Thumbnail/" + gallery.ImageName));

                    _galleryBusiness.Insert(gallery);
                    _galleryBusiness.Save();
                    return RedirectToAction("Gallery", new { id = gallery.ProductId });
                }
            }
            
            return RedirectToAction("Gallery", new { id = gallery.ProductId });
        }

        public ActionResult DeleteGallery(int id)
        {
            var gallery = _galleryBusiness.GetById(id);
            System.IO.File.Delete(Server.MapPath("/Content/Image/Product/" + gallery.ImageName));
            System.IO.File.Delete(Server.MapPath("/Content/Image/Product/Thumbnail/" + gallery.ImageName));
            _galleryBusiness.Delete(id);
            _galleryBusiness.Save();
            return RedirectToAction("Gallery", new { id = gallery.ProductId});
        }
    }
}
