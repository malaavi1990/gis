using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MohatechDomain
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
