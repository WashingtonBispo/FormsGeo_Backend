﻿using FormsGeo.Data.Context;
using FormsGeo.Service.User.Handle;
using FormsGeo.Service.User.Request;
using FormsGeo.Service.User.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormsGeo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<UserResponse> Post([FromBody] UserPostRequest request)
        {
            var userPostHandle = new UserPostHandle(request, _context, _configuration);
            return await userPostHandle.Handle();
        }

        // Get api/<UserController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<UserResponse> Get([FromQuery] UserGetRequest request)
        {
            var userGetHandle = new UserGetHandle(request, _context, _configuration);
            return await userGetHandle.Handle();
        }
    }
}
