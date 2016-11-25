using System.Net;
using System.Net.Mail;
using System.Web.Http;
using GakuenEmailSender.Models;

namespace GakuenEmailSender.Controllers
{
    public class MessageController : ApiController
    {
        // POST: api/EventMessages
        public IHttpActionResult PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress("martin1-g@hotmail.com"));  // replace with valid value 
            mailMessage.From = new MailAddress("gakuenreply@gmail.com");  // replace with valid value
            mailMessage.Subject = "Your email subject";
            mailMessage.Body = string.Format(body, "Name", "gakuenreply@gmail.com", "Hello");
            mailMessage.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "gakuenreply@gmail.com",  // replace with valid value
                    Password = "p@ssW0rd"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.SendMailAsync(mailMessage);
            }



            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }
    }
}
