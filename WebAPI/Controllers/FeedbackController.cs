using Business.Abstract;
using Entities.Concrete;
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
    public class FeedbackController : ControllerBase
    {
        IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("add")]
        public IActionResult Add(Feedback feedback)
        {
            var result = _feedbackService.Add(feedback);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Feedback feedback)
        {
            var result = _feedbackService.Update(feedback);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _feedbackService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyeventid")]
        public IActionResult GetByEventId(int id)
        {
            var result = _feedbackService.GetAllByEventId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getfeedbackdtos")]
        public IActionResult GetFeedbackDtos()
        {
            var result = _feedbackService.GetFeedbackDtos();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }
}
