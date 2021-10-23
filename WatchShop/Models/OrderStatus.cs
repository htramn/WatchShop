using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set;}

        [StringLength(50)]
        public string StatusName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}