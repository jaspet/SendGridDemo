using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SendGridDemo.Data.Models
{
    public class MessageBase
    {
        [Key]
        public int pkMessageId { get; set; }
        [MaxLength(100)]
        public string MessageId { get; set; }
        public string To { get; set; }
        public string MessageText { get; set; }
    }
}
