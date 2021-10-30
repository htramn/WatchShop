﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class PaymentMethod
    {
        [Key]
        public int MethodId { get; set; }

        [StringLength(100)]
        public string MethodName { get; set; }
    }
}