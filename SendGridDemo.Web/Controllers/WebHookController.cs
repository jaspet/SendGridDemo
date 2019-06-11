using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGridDemo.Data;
using SendGridDemo.Data.Models;
using System.Linq;
using System.Net;

namespace SendGridDemo.Web.Controllers
{

    public class WebHookController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendGridWebhook([FromBody] SendGridEvent[] eventList, [FromServices]AppDbContext dbContext)
        {
            foreach (var emailEvent in eventList)
            {
                if (emailEvent.AuthenticationSignature != GetAuthenticationSignature())
                {
                    return new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                }
                string messageId = emailEvent.sg_message_id;
                var index = emailEvent.sg_message_id.IndexOf(".");
                if (index != -1)
                {
                    messageId = emailEvent.sg_message_id.Substring(0, emailEvent.sg_message_id.IndexOf("."));
                }
                messageId = messageId.Replace("filter", string.Empty);
                var emailMessage = dbContext.EmailMessages.Include(x => x.EmailEvents).SingleOrDefault(x => x.MessageId == messageId);
                if (emailMessage == null)
                {
                    return new StatusCodeResult((int)HttpStatusCode.ExpectationFailed); // we don't have the item in our DB yet
                }
                emailMessage.EmailEvents.Add(
                        new EmailMessageEvent()
                        {
                            Event = emailEvent.@event,
                            TimeStamp = emailEvent.timestamp,
                            SendGridEventId = emailEvent.sg_event_id,
                            Response = emailEvent.response,
                            Url = emailEvent.url,
                        });
            }
            dbContext.SaveChanges();
            return new StatusCodeResult((int)HttpStatusCode.OK);
        }

        private string GetAuthenticationSignature()
        {
            return "SomeAuthenticationSignature";
        }
    }
}
