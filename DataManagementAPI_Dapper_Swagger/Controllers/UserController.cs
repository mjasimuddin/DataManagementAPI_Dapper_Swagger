﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagementAPI_Dapper_Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        IUserManager _userManager;
       
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userManager.GetAllUser();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userManager.GetUserById(id);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _userManager.AddUser(user);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            _userManager.UpdateUser(user);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userManager.DeleteUser(id);
        }
    }
}
