using SendGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendGridDemo.Data.Services
{
    public interface IEmailSender
    {
        Task<Response> SendEmailAsync(string email, string subject, string messageBody);
        Task<Response> SendAdminEmailAsync(string subject, string messageBody);
        Task<Response> SendEmailWithAttachmentAsync(string email, string subject, string messageBody, string fileName, string content);
    }
}
