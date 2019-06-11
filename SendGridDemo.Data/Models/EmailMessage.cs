using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using SendGridDemo.Data.Services;
using SendGridDemo.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SendGridDemo.Data.Models
{
    [Table("EmailMessage")]
    public class EmailMessage : MessageBase
    {

        [MaxLength(100)]
        public string Subject { get; set; }

        [Coalesce]
        public static async Task<string> SendEmail(string to, string subject, string message, AppDbContext db, [Inject] IEmailSender emailSender)
        {
            try
            {
                EmailMessage newMsg = new EmailMessage() { To = to, Subject = subject, MessageText = message };
                var result = await emailSender.SendEmailAsync(to, subject, message);
                var data = result.DeserializeResponseHeaders(result.Headers);
                string messageId = data["X-Message-Id"];
                newMsg.MessageId = messageId;
                db.EmailMessages.Add(newMsg);
                db.SaveChanges();

                db.EmailMessageEvents.Add(new EmailMessageEvent()
                {
                    fkEmailMessageId = newMsg.pkMessageId,
                    Event = "Api Called From Demo App",
                    TimeStamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Subtract(TimeSpan.FromSeconds(1)).TotalSeconds,
                });

                db.SaveChanges();

                return "Success";
            }
            catch (Exception e)
            {
                return $"Failed: {e.Message}";
            }
        }

        public ICollection<EmailMessageEvent> EmailEvents { get; set; }
        [NotMapped]
        public string LastStatus
        {
            get
            {
                if (EmailEvents != null && EmailEvents.Any())
                {
                    var ev = EmailEvents.OrderBy(x => x.TimeStamp).Last();
                    return $"{ev.Event.GetEventName()} ({ev.EventTime.UtcTimeToPacificStandardTimeAsStringShort()})";
                }
                return "NA";
            }
        }
    }
}
