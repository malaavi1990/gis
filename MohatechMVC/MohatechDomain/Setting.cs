using System.ComponentModel.DataAnnotations;

namespace MohatechDomain
{
    public class Setting
    {
        public int SettingId { get; set; }

        [Display(Name = "عنوان سایت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(30, MinimumLength =3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string SiteTitle { get; set; }

        [Display(Name = "توضیحات")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Description { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Keyword { get; set; }

        [Display(Name = "متن کپی رایت")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string CopyRight { get; set; }

        [Display(Name = "آدرس")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "تلفن تماس")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل پشتیبانی")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "{0} را بدرستی وارد کنید")]
        public string SupportEmail { get; set; }

        [Display(Name = "ایمیل اطلاعات")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "{0} را بدرستی وارد کنید")]
        public string InfoEmail { get; set; }
    }
}
