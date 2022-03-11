﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.Data.Helper;
using SystemManagement.Data.ViewModel;
using SystemManagement.Service;

namespace SystemManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;         
        }    
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromQuery]LoginViewModel loginViewModel)
        {
            var result = await _userService.Login(loginViewModel);

            var Message = string.Empty;        

            if (result == "Unauthorized")
            {
                return Unauthorized();
            }
            if (result == "NotMatch")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "UserName Or Password Not Match!" });
            }
            return Ok(new { token =result});
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromQuery] RegisterViewModel registerViewModel)
        {
            var result = await _userService.Register(registerViewModel);
            if (result == "UserNameExist")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }
            if (result == "EmailExist")
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email already exists!" });
            }
        
            if (result == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            }
            return Ok(new Response { Status = "Success", Message = "created successfully!" });
        }
       
    }
}
