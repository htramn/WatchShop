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
        public static string getDate(DateTime x)
        {
            return x.ToString("dd");
        }
        public static string getMonthYear(DateTime x)
        {
            return x.ToString("MMMM yyyy");
        }
        public static string getDateFull(DateTime x)
        {
            return x.ToString("MMMM dd, yyyy");
        }
    }
}