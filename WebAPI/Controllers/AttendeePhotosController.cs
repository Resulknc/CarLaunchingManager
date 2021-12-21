using Business.Abstract;
using Core.Utilities.CloudinaryOperations;
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
    public class AttendeePhotosController : ControllerBase
    {
    
        private readonly IAttendeeService _attendeeService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IAttendeePhotoService _photoService;

        public AttendeePhotosController(IAttendeeService attendeeService, ICloudinaryService cloudinaryService, IAttendeePhotoService photoService)
        {
            _attendeeService = attendeeService;
            _cloudinaryService = cloudinaryService;
            _photoService = photoService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _photoService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getphotosbyattendeeid")]
        public IActionResult GetPhotosByCarId(int attendeeId)
        {
            var result = _photoService.GetPhotosByAttendeeId(attendeeId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add/{attendeeId}")]
        public IActionResult AddPhoto(IFormFile file, int attendeeId)
        {
            var currentAttendee = _attendeeService.GetByAttendeeId(attendeeId);
            var result = _cloudinaryService.AddPhoto(file);

            currentAttendee.Data.AttendeePhotos = _photoService.GetPhotosByAttendeeId(attendeeId).Data;

            if (result.Data.Error != null)
            {
                return BadRequest(result.Data.Error.Message);
            }

            var photo = new AttendeePhoto
            {
                Url = result.Data.SecureUrl.AbsoluteUri,
                PublicId = result.Data.PublicId,
                Description = "example",
                AttendeeId = attendeeId,
                Attendee = currentAttendee.Data,
                DateAdded = DateTime.Now,
                IsMain = false

            };

            if (!currentAttendee.Data.AttendeePhotos.Any(p => p.IsMain))
            {
                photo.IsMain = true;
            }


            currentAttendee.Data.AttendeePhotos.Add(photo);

            if (!(result.Success))
            {
                return BadRequest("Error Ocuured ");
            }

            _photoService.Add(photo);



            return Ok(photo.IsMain);
        }
    }
}
