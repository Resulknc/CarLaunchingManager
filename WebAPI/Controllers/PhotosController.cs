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
    [Route("api/cars/{carId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IPhotoService _photoService;

        public PhotosController(ICarService carService, IPhotoService photoService)
        {
            _carService = carService;
            _photoService = photoService;
        }

        [HttpPost("add")]
        public IActionResult AddPhoto(IFormFile file, int carId)
        {
            var currentCar = _carService.GetById(carId);
            var result = _photoService.AddPhoto(file);

            if(result.Data.Error != null)
            {
                return BadRequest(result.Data.Error.Message);
            }

            var photo = new Photo
            {
                Url = result.Data.SecureUrl.AbsoluteUri,
                PublicId = result.Data.PublicId
            };

            if (currentCar.Data.Photos.Count > 0)
            {
                photo.IsMain = true;
            }
            currentCar.Data.Photos.Add(photo);
            
            return Ok(photo.IsMain);
        }
    }
}
