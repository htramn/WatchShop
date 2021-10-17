using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [StringLength(300)]
        public string Code { get; set; }

        [Column(TypeName = "float")]
        public float Percent { get; set; }

        public long Quantity { get; set; }

        public bool Status { get; set; }

    }
}