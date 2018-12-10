using System.ComponentModel.DataAnnotations;

namespace MohatechViewModel
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "کلمه عبور فعلی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیست")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
