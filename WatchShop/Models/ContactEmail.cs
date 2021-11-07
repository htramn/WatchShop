using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchShop.EntityFramework
{
    public class ContactEmail
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Gửi đền từ")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Display(Name = "Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Người trả lời")]
        public int? RespondentId { get; set; }

        [ForeignKey("RespondentId")]
        public virtual User Respondent { get; set; }
    }
}