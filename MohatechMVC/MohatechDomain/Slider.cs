using System.ComponentModel.DataAnnotations;

namespace MohatechDomain
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "ترتیب نمایش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Sort { get; set; }
    }
}
