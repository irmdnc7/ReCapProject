using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;

        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(millisecondsTimeout: 5000);
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        
       
       
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _carService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
          [HttpGet("getcarsdetails")]
        public IActionResult GetCarsDetails([FromQuery]CarDetailFilterDto filterDto)
        {
            var test = HttpContext.Request.Query["brandid"];
            var result = _carService.GetCarsDetails(filterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
    
}
        

    
    

