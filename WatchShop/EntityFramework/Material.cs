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

        [StringLength(300)]
        public string MaterialName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}