using Business.Abstract;
using Business.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        [HttpGet("deneme")]
        public IActionResult deneme()
        {
            return Ok("deneme");
        }
        private MailManager mailManager;

        private readonly IMailService _mailService;

        public MailsController()
        {
            //_mailService = mailService;
            mailManager = new MailManager();
        }

        [HttpPost("sendPassword")]
        public IActionResult SendPassword(AttendeeForEmailDto attendee)
        {
            var result = mailManager.Send(attendee.Email, attendee.AttendeeName);
            return Ok(result);
        }

    }
}
