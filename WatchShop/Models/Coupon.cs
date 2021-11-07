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

        [Display(Name = "Mã giảm giá")]
        [Index(IsUnique = true)]
        [StringLength(300)]
        public string Code { get; set; }

        [Display(Name = "Phần trăm giảm")]
        [Range(1,100)]
        public decimal? Discount { get; set; }

        [Display(Name = "Giảm giá tối đa")]

        [Column(TypeName = "money")]
        public decimal? MaxDiscount { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }

    }
}