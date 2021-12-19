using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Services
{
    public class MailService
    {
        private IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(string sendTo, string subject, string body)
        {
            MailMessage oMailMessage = new MailMessage();

            oMailMessage.From = new MailAddress(configuration["Email:EmailAddress"]);
            oMailMessage.To.Add(sendTo);
            oMailMessage.Subject = subject;
            oMailMessage.Body = body;


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(configuration["Email:EmailAddress"], configuration["Email:EmailPassword"]);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

               await client.SendMailAsync( oMailMessage);
            }
        }

        public async Task Send(string sendTo, string subject, string body, Attachment oAttachment)
        { 
            MailMessage oMailMessage = new MailMessage();

            oMailMessage.From = new MailAddress(configuration["Email:EmailAddress"]);
            oMailMessage.To.Add(sendTo);
            oMailMessage.Subject = subject;
            oMailMessage.Body = body;
            oMailMessage.Attachments.Add(oAttachment);

            using (SmtpClient client = new SmtpClient())
            {
                
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(configuration["Email:EmailAddress"], configuration["Email:EmailPassword"]);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

               await client.SendMailAsync(oMailMessage);
            }
        }
    }
}
