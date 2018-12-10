using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MohatechDomain
{
    public class Role
    {
        public int RoleId { get; set; }

        [Display(Name = "نقش کاربر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد")]
        public String RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
