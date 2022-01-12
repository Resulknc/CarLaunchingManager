using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mailkit
{
    public class MailkitManager : IMailkitService
    {
        private readonly IOptions<MailkitSettings> _mailkitConfig;
        private readonly MailkitSettings _mailkitSettings;

        public MailkitManager(IOptions<MailkitSettings> mailkitConfig, MailkitSettings mailkitSettings)
        {
            _mailkitConfig = mailkitConfig;
            _mailkitSettings = mailkitSettings;
        }

        public void SendPassword(string email,string attendeeName)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Launchfy",_mailkitConfig.Value.Email));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "Your Password";

            message.Body = new TextPart("plain")
            {
                Text = "Dear " + attendeeName + @" your launchfy password is " + "mercedesLaunchfy"
            };

            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect(_mailkitConfig.Value.Client,465, true);
                smtpClient.Authenticate(_mailkitConfig.Value.Email, _mailkitConfig.Value.Password);
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
