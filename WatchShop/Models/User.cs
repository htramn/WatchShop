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
        [Display(Name="Tên đăng nhập")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        public int? UserRoleId { set; get; }

        [StringLength(300)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [StringLength(300)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Tỉnh/Thành phố")]
        public string Province { set; get; }
        [Display(Name = "Quận/Huyện")]
        public string District { set; get; }

        public bool Status { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Người cập nhật")]
        public string ModifiedBy { get; set; }

        public virtual UserRole UserRole { get; set; } 
        public virtual ICollection<Order> Orders { get; set; }

    }
}