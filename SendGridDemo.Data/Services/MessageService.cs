using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridDemo.Data.Utilities;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendGridDemo.Data.Services
{
    public class MessageService : IEmailSender, ISmsSender
    {
        string _SmsAccountSid;
        string _SmsAuthToken;
        string _SendGridApiKey;
        string _ReplyEmail;
        string _SmsPhoneNumber;
        string _AdminEmails;

        public MessageService() { }
        public MessageService(string smsAccountSid, string smsAuthToken, string smsPhoneNumber, string sendGridApiKey, string replyEmail, string adminEmails)
        {
            _SmsAccountSid = smsAccountSid;
            _SmsAuthToken = smsAuthToken;
            _SmsPhoneNumber = smsPhoneNumber;
            _SendGridApiKey = sendGridApiKey;
            _ReplyEmail = replyEmail;
            TwilioClient.Init(_SmsAccountSid, _SmsAuthToken);
            _AdminEmails = adminEmails;
        }

        public async Task<Response> SendEmailWithAttachmentAsync(string email, string subject, string messageBody, string attachmentFileName, string content)
        {
            var client = new SendGridClient(_SendGridApiKey);

            var message = new SendGridMessage
            {
                From = new EmailAddress(_ReplyEmail),
                Subject = subject.OrDefault("Communication from SendGrid Demo"),
                PlainTextContent = messageBody
            };

            var emails = email.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var em in emails)
            {
                message.AddTo(em.Trim());
            }

            message.AddAttachment(attachmentFileName, content);

            return await client.SendEmailAsync(message);
        }

        public void AddAuthenticationSignature(SendGridMessage msg)
        {
            msg.AddCustomArg("AuthenticationSignature", "SomeAuthenticationSignature");
        }

        public async Task<Response> SendEmailAsync(string email, string subject, string messageBody)
        {
            var client = new SendGridClient(_SendGridApiKey);

            var message = new SendGridMessage
            {
                From = new EmailAddress(_ReplyEmail),
                Subject = subject.OrDefault("Communication from SendGrid Demo"),
                HtmlContent = messageBody
            };
            AddAuthenticationSignature(message);

            var emails = email.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var em in emails)
            {
                message.AddTo(em.Trim());
            }

            var response = await client.SendEmailAsync(message);
            return response;
        }

        public async Task<Response> SendAdminEmailAsync(string subject, string messageBody)
        {
            return await SendEmailAsync(_AdminEmails, subject, messageBody);
        }

        public MessageResource SendSms(string phoneNumber, string message)
        {
            return SendSms(phoneNumber, "No Subject", message);
        }

        public MessageResource SendSms(string phoneNumber, string subject, string message)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException(nameof(phoneNumber));
            if (string.IsNullOrEmpty(subject)) throw new ArgumentNullException(nameof(subject));
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            var to = new PhoneNumber(phoneNumber);
            var smsMessage = MessageResource.Create(
                to,
                from: new PhoneNumber(_SmsPhoneNumber),
                body: message);
            return smsMessage;

        }
    }
}
