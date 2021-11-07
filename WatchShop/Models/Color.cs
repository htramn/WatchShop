using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Color
    {
        [Display(Name = "Mã màu")]
        [Key]
        public int ColorId { get; set; }

        [Display(Name = "Tên màu")]
        [StringLength(300)]
        public string ColorName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}