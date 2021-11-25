using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchShop.ViewModel
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
        public int? UserRoleId { set; get; }
    }
}