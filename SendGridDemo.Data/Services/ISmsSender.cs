using Twilio.Rest.Api.V2010.Account;

namespace SendGridDemo.Data.Services
{
    public interface ISmsSender
    {
        MessageResource SendSms(string phoneNumber, string message);
        MessageResource SendSms(string phoneNumber, string subject, string message);
    }
}
