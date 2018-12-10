﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MohatechDomain
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(400, MinimumLength = 20, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        //[DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "متن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        //[DataType(DataType.MultilineText)]
        //[AllowHtml]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

    }
}