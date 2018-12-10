using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MohatechDomain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Title { get; set; }

 
        public int ParentId { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
