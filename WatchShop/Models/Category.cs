using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(300)]
        [Display(Name = "Loại")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}