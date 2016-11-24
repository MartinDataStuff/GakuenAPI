using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Text;
using GakuenAPI.Models;

namespace GakuenAPI.Controllers
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

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            // set up the Gmail server
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential(Message.Sender, Message.Code);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            // draft the email
            MailAddress fromAddress = new MailAddress(Message.Sender);
            email.From = fromAddress;
            email.To.Add(message.Reciever);
            email.Subject = message.Header;
            email.Body = message.Body;

            smtp.Send(email);



            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }
    }
}
