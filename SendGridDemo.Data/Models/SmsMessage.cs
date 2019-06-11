using IntelliTect.Coalesce;
using System;
using System.ComponentModel.DataAnnotations;

namespace SendGridDemo.Data.Models
{
    public class SmsMessage : MessageBase
    {
        [MaxLength(100)]
        public string Subject { get; set; }

        [Coalesce]
        public static string SendSms(string to, string message, AppDbContext db)
        {
            try
            {
                SmsMessage newMessage = new SmsMessage() { To = to, MessageText = message };
                db.SmsMessages.Add(newMessage);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return $"Failed: {e.Message}";
            }
        }
    }
}
