using Business.Abstract;
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
    public class AuthAttendeeController : Controller
    {
        IAuthAttendeeService _authAttendeeService;
        private readonly IMailService _mailService;

        public AuthAttendeeController(IAuthAttendeeService authAttendeeService, IMailService mailService)
        {
            _authAttendeeService = authAttendeeService;
            _mailService = mailService;
        }

        [HttpPost("login")]
        public ActionResult Login(AttendeeForLoginDto attendeeForLoginDto)
        {
            var attendeeToLogin = _authAttendeeService.Login(attendeeForLoginDto);
            if (!attendeeToLogin.Success)
            {
                return BadRequest(attendeeToLogin.Message);
                //return Ok(attendeeToLogin.Message);

            }
            var result = _authAttendeeService.CreateAccessToken(attendeeToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(attendeeToLogin.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(AttendeeForRegisterDto attendeeForRegisterDto)
        {
            var userExists = _authAttendeeService.AttendeeExists(attendeeForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var result = _authAttendeeService.Register(attendeeForRegisterDto);

            //var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }

        private void SendEmail(AttendeeForEmailDto attendee)
        {
            _mailService.Send(attendee.Email, attendee.AttendeeName);
        }
    }
}
