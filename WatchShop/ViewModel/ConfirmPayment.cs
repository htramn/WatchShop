using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WatchShop.EntityFramework;
using WatchShop.Models;

namespace WatchShop.ViewModel
{
    [Serializable]
    public class ConfirmPayment
    {
        public List<CartItem> ListProduct { get; set; }

        
        [StringLength(300)]
        public string Code { get; set; }
       
        public int? MethodId { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public decimal? Total { get
            {
                decimal? tong = 0;
                foreach(var item in ListProduct)
                {
                    tong += item.Product.SalePrice * item.Quantity;
                }
                return tong;
            }
        }
        public decimal? TotalPayment { get { return Total - Discount; } }

        public decimal? Discount
        {
            get
            {
                if (Code == null)
                {
                    return 0;
                }
                else
                {
                    if (Total * Coupon.Discount > Coupon.MaxDiscount)
                    {
                        return Coupon.MaxDiscount;

                    }
                    else
                    {
                        return Total * Coupon.Discount;
                    }
                }

            }
        }
        [ForeignKey("Code")]
        public virtual Coupon Coupon { get; set; }

        [ForeignKey("MethodId")]
        public virtual PaymentMethod PaymentMethod { get; set; }


    }
}