﻿using System.Net;
using System.Net.Mail;

namespace Library_Mngmt_System.EmailServicee
{
    public class EmailServicee
    {
        public EmailServicee(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void SendEmail(string toEmail, string subject, string body)
        {
            var fromEmail = Configuration.GetSection("Constants:FromEmail").Value ?? string.Empty;
            var fromEmailPass = Configuration.GetSection("Constants: EmailAccountPassword").Value ?? string.Empty;
            var message = new MailMessage()
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            };
            message.To.Add(toEmail);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromEmailPass),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
    }
}
