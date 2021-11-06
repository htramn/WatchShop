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

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public bool Status { get; set; }
        public int? RespondentId { get; set; }

        [ForeignKey("RespondentId")]
        public virtual User Respondent { get; set; }
    }
}