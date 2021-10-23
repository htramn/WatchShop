using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [StringLength(300)]
        public string UserRoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}