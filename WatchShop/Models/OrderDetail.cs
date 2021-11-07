using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Display(Name = "Mã đơn hàng")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Display(Name = "Mã sản phẩm")]

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Display(Name = "Số lượng")]
        public long Quantity { get; set; }

        [Display(Name = "Giá bán")]

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}