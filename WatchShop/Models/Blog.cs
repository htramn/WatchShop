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

        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        [ForeignKey("CreatedPerson")]
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("ModifiedPerson")]
        public int? ModifiedBy { get; set; }

        public virtual User CreatedPerson { get; set; }

        public virtual User ModifiedPerson { get; set; }
    }
}