using Business.Abstract;
using Core.Utilities.Mailkit;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        private readonly IMailkitService _mailkitService;

        public MailManager(IMailkitService mailkitService)
        {
            _mailkitService = mailkitService;
        }

        public IResult Send(string email, string attendeeName)
        {
            _mailkitService.SendPassword(email, attendeeName);
            return new SuccessResult();
        }
    }
}
