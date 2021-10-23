using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [StringLength(300)]
        public string ColorName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}