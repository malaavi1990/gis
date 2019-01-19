using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MohatechDomain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(400, MinimumLength = 20, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "متن")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "قیمت")]
        public long Price { get; set; }

        [Display(Name = "تصویر")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int Sort { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
