using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Display(Name = "Chất liệu")]
        [StringLength(300)]
        public string MaterialName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}