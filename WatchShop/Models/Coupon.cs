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

        [Index(IsUnique = true)]
        [StringLength(300)]
        public string Code { get; set; }

        [Range(1,100)]
        public decimal? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxDiscount { get; set; }

        public long Quantity { get; set; }

        public bool Status { get; set; }

    }
}