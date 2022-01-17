using Business.Abstract;
using Core.Utilities.Mailkit;
using Core.Utilities.Results;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        //private readonly IMailkitService _mailkitService;

        //public MailManager(IMailkitService mailkitService)
        //{
        //    //_mailkitService = mailkitService;
        //}

        public IResult Send(string email, string attendeeName)
        {
            SendPassword(email, attendeeName);
            return new SuccessResult();
        }

        public void SendPassword(string email, string attendeeName)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Launchfy", "launchfysdc@gmail.com"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "Your Password";

            message.Body = new TextPart("plain")
            {
                Text = "Dear " + attendeeName + @" your launchfy password is " + "mercedesLaunchfy"
            };

            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("launchfysdc@gmail.com", "Launchfysdc1.");
                smtpClient.Send(message);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
