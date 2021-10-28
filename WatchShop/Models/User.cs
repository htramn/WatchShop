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

        public int? UserRoleId { set; get; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? ProvinceId { set; get; }

        public int? DistrictId { set; get; }

        public bool Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}