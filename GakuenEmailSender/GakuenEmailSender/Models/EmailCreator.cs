using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Web.Http;
using GakuenEmailSender.Models;

namespace GakuenEmailSender.Models
{
    class EmailCreator
    {
        public async Task SendAsync(Message message)
        {
            await ConfigSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task ConfigSendGridasync(Message message)
        {
            var myMessage = new MailMessage();
            myMessage.To.Add("martin1-g@hotmail.com");
            myMessage.From = new System.Net.Mail.MailAddress(
                "gakuenreply@gmail.com", "Joe S.");
            myMessage.Subject = message.Header;
            myMessage.Body = message.Body;

            using (var smtp = new SmtpClient())
            {
                var credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["gakuenreply@gmail.com"],
                    ConfigurationManager.AppSettings["p@ssW0rd"]
                );
                // Create a Web transport for sending email.
                smtp.Credentials = credentials;

                // Send the email.
                if (smtp.Credentials != null)
                {
                    await smtp.SendMailAsync(myMessage);
                }
                else
                {
                    Trace.TraceError("Failed to create Web transport.");
                    await Task.FromResult(0);
                }
            }

        }
    }
}
