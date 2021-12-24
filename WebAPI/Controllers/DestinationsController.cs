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
    public class DestinationsController : ControllerBase
    {
        IDestinationService _destinationService;

        public DestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _destinationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbydestinationid")]
        public IActionResult GetByDestinationId(int id)
        {
            var result = _destinationService.GetByDestinationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Destination destination)
        {
            var result = _destinationService.Add(destination);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Destination destination)
        {
            var result = _destinationService.Delete(destination);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Destination destination)
        {
            var result = _destinationService.Update(destination);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getdestinationbycountryid")]
        public IActionResult GetByDestinationByCountryId(int countryId)
        {
            var result = _destinationService.GetDestinationByCountryId(countryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("getdestinationbycountry")]
        public IActionResult GetByDestinationByCountry(Country country)
        {
            var result = _destinationService.GetDestinationByCountry(country);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("deletebydestinationname")]
        public IActionResult DeleteCountryByName(string destinationName)
        {

            var result = _destinationService.DeleteByDestinationName(destinationName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycountryname")]
        public IActionResult GetByUsername(string destinationName)
        {
            var result = _destinationService.GetByDestinationName(destinationName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
