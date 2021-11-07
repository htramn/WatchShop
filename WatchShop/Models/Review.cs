using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Display(Name = "Sản phẩm")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Display(Name = "Khách hàng")]

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Nội dung")]

        [Column(TypeName = "ntext")]
        public string Comment { get; set; }
        [Display(Name = "Khách hàng")]
        public virtual User Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}