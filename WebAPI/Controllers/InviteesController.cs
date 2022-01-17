using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteesController : ControllerBase
    {
        IInviteeService _inviteeService;

        public InviteesController(IInviteeService inviteeService)
        {
            _inviteeService = inviteeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _inviteeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyinviteeid")]
        public IActionResult GetByInviteeId(int id)
        {
            var result = _inviteeService.GetByInviteeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Invitee invitee)
        {
            var result = _inviteeService.Add(invitee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Invitee invitee)
        {
            var result = _inviteeService.Delete(invitee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Invitee invitee)
        {
            var result = _inviteeService.Update(invitee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletebyeventandattendeeid")]
        public IActionResult DeleteByEventAndAttendeeId(int eventId, int attendeeId)
        {
            var result = _inviteeService.DeleteByEventAndAttenedeeId(eventId, attendeeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getinviteesbyeventid")]
        public IActionResult GetInviteesByEventId(int eventId)
        {
            var result = _inviteeService.GetInviteesByEventId(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}