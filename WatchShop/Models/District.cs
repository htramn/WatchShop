using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchShop.Models
{
    public class District
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int ProvinceID { set; get; }
    }
}