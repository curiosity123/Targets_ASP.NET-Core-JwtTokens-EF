﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private readonly IUserService service;

        public UsersController(IUserService userService)
        {
            service = userService;
        }



        [HttpGet("{Email}, {Password}")]
        public IUser Get(string Email, string Password)
        {
            return service.Get(Email, Password);
        }


        [HttpPost("RegisterAccount")]
        public void Post([FromBody] RegisterUserDto usr)
        {
            if (usr != null)
                service.RegisterAccount(usr.Email, usr.Password);
        }


        [HttpDelete("DeleteAccount")]
        public void Delete([FromBody] RegisterUserDto usr)
        {
            if (usr != null)
                service.DeleteAccount(usr.Email, usr.Password);
        }

    }
}