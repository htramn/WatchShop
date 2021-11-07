using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchShop.EntityFramework
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Display(Name ="Tiêu đề")]
        [StringLength(300)]
        public string Title { get; set; }

        [Display(Name = "Tóm tắt")]
        public string Description { get; set; }

        [Display(Name = "Ảnh")]
        [StringLength(300)]
        public string Image { get; set; }

        [Display(Name = "Nội dung")]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Display(Name = "Ngày viết")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Người viết")]

        [ForeignKey("CreatedPerson")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Ngày sửa")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Người viết")]

        [ForeignKey("ModifiedPerson")]
        public int? ModifiedBy { get; set; }

        public virtual User CreatedPerson { get; set; }

        public virtual User ModifiedPerson { get; set; }
    }
}