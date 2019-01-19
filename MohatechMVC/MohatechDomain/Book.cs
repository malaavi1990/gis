using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MohatechDomain
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

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

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }

        [Display(Name = "تصویر")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
    }
}
