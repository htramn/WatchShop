using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email!")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public bool Status { get; set; }


    }
}