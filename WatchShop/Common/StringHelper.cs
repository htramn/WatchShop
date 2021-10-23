using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchShop.Common
{
    public class StringHelper
    {
        public static string CurrencyFormat(decimal? x)
        {
            return String.Format("{0:0,0đ}", x);
        }
    }
}