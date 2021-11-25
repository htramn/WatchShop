using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Display(Name ="Khách hàng")]
        public int UserId { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }

        
        [ForeignKey("OrderStatus")]
        [Display(Name = "Trạng thái đơn hàng")]
        public int StatusId { get; set; }

       
        [ForeignKey("PaymentMethod")]
        [Display(Name = "Phương thức thanh toán")]
        public int? MethodId { get; set; }

       
        [ForeignKey("Coupon")]
        [Display(Name = "Mã giảm giá")]
        public int? CouponId{ get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(500)]
        public string Note { get; set; }

        [Display(Name = "Tổng thanh toán")]
        public decimal? TotalPayment { get; set; }


        public virtual OrderStatus OrderStatus { get; set; }

        public virtual Coupon Coupon { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        
        public virtual PaymentMethod PaymentMethod { get; set; }

    }
}