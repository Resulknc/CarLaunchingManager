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
    [Route("api/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IPhotoService _photoService;

        public PhotosController(ICarService carService, ICloudinaryService cloudinaryService, IPhotoService photoService)
        {
            _carService = carService;
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

        [HttpGet("getphotosbycarid")]
        public IActionResult GetPhotosByCarId(int carId)
        {
            var result = _photoService.GetPhotosByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add/{carId}")]
        public IActionResult AddPhoto(IFormFile file, int carId)
        {
            var currentCar = _carService.GetById(carId);
            var result = _cloudinaryService.AddPhoto(file);

            currentCar.Data.Photos = _photoService.GetPhotosByCarId(carId).Data;

            if(result.Data.Error != null)
            {
                return BadRequest(result.Data.Error.Message);
            }

            var photo = new Photo
            {
                Url = result.Data.SecureUrl.AbsoluteUri,
                PublicId = result.Data.PublicId,
                Description = "example",
                CarId = carId,
                Car = currentCar.Data,
                DateAdded = DateTime.Now,
                IsMain = false

        };

            if (!currentCar.Data.Photos.Any(p => p.IsMain))
            {
                photo.IsMain = true;
            }
           

            currentCar.Data.Photos.Add(photo);

            if (!(result.Success))
            {
                return BadRequest("Error Ocuured ");
            }

           _photoService.Add(photo);


            
            return Ok(photo.IsMain);
        }
    }
}
