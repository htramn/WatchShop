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

        [StringLength(300)]
        public string SupplierName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}