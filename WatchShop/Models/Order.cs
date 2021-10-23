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

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public DataType OrderDate { get; set; }

        [ForeignKey("OrderStatus")]
        public int StatusId { get; set; }


        [ForeignKey("Coupon")]
        public int? CouponId{ get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual User Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual User Employee { get; set; }

    }
}