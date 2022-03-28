﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Data.Entities;
using SystemManagement.Data.Helper;
using SystemManagement.Service;

namespace SystemManagement.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarService _carService;
        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]  
        [Authorize(Roles = "Admin")]
        public JsonResult GetCar()
        {
            var result = _carService.GetCarByID();
            return new JsonResult(result);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddCar(Car car)
        {
            var result= await _carService.AddCar(car);
            return Ok(result);
        }
    }
}
