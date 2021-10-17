﻿using System;
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
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}