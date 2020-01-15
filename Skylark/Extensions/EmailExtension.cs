using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Skylark.Models;
using Skylark.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace Skylark.Extensions
{
    public class EmailExtension : SmtpClient
    {

        private static IConfiguration _config;
        public EmailExtension(IConfiguration config)
        {
            _config = config;
        }

        public static void SendEmail(EmailVM emailVM)
        {
            try
            {
                var credential = new NetworkCredential
                {
                    UserName = "Quorra",
                    Password = "bAz/"
                };

                var message = new MailMessage();
                message.To.Add(new MailAddress(emailVM.EmailAddress));
                if (emailVM.CCEmailAddress != null)
                {
                    message.CC.Add(new MailAddress(emailVM.CCEmailAddress));
                }
                message.From = new MailAddress("noreply-Skylark@absa.co.za");
                message.Subject = emailVM.Subject;
                message.Body = emailVM.Message;
                message.IsBodyHtml = true;

                //List<MemoryStream> streams = new List<MemoryStream>();

                //if (emailVM.EmailAttachments != null)
                //{
                //    foreach (Tuple<string, byte[]> file in emailVM.EmailAttachments)
                //    {
                //        MemoryStream fileStream = new MemoryStream(file.Item2);
                //        message.Attachments.Add(new Attachment(fileStream, file.Item1));
                //        streams.Add(fileStream);
                //    }
                //}

                using (var smtp = new SmtpClient())
                {
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.absa.co.za";
                    smtp.Port = Int32.Parse("25");
                    smtp.EnableSsl = Boolean.Parse("false");
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
