using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public int UserRoleId { set; get; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email!")]
        public string Email { get; set; }

        [StringLength(11)]
        [RegularExpression(@"/(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b/", ErrorMessage = "Please enter correct phone!")]
        public string Phone { get; set; }

        public int? ProvinceId { set; get; }

        public int? DistrictId { set; get; }

        public bool Status { get; set; }

        public virtual UserRole UserRole { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}