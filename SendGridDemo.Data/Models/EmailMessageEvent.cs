using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SendGridDemo.Data.Models
{
    [Table("EmailMessageEvent")]
    public class EmailMessageEvent
    {
        [Key]
        public int EmailMessageEventId { get; set; }
        public int fkEmailMessageId { get; set; }
        [ForeignKey("fkEmailMessageId")]
        public EmailMessage EmailMessage { get; set; }
        public double TimeStamp { get; set; }
        public DateTime EventTime
        {
            get
            {
                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                return time.AddSeconds(TimeStamp);
            }
        }
        public string Event { get; set; }
        [MaxLength(100)]
        public string SendGridEventId { get; set; }
        public string Response { get; set; }
        public string Url { get; set; }
    }
}
