using System.ComponentModel.DataAnnotations;

namespace MohatechViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, MinimumLength = 11, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "{0} را بدرستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیست")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string LastName { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "{0} را بدرستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "{0} را بدرستی وارد کنید")]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Display(Name = "کلمه عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیست")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
