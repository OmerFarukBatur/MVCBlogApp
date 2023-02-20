using Microsoft.Extensions.Configuration;
using MVCBlogApp.Application.Abstractions.Services;
using System.Net.Mail;
using System.Net;

namespace MVCBlogApp.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {

            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            mail.Body = body;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
            mail.From = new(_config["Mail:Username"], _config["Mail:DisplayName"], System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            smtp.Port = int.Parse(_config["Mail:Port"]);
            smtp.EnableSsl = true;
            smtp.Host = _config["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }
    }
}
