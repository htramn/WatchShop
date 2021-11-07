using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Display(Name = "Nhà cung ứng")]

        [StringLength(300)]
        public string SupplierName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}