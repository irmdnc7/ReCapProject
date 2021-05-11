using Business.Abstract;
using Core.Utilities.Results;
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
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;


        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbycarid")]
        public IActionResult GetImagesById([FromForm(Name = ("CarId"))] int carId)
        {
            var result = _carImagesService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm]  CarImages carImages , [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            IResult result = _carImagesService.Add(carImages, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImages carImages)
        {
            IResult result = _carImagesService.Delete(carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImages carImages, [FromForm] IFormFile file)
        {

            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            IResult result = _carImagesService.Update(carImages, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}