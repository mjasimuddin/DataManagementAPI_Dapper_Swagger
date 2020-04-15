using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataManagementAPI_Dapper_Swagger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateServcie;
        public AuthenticationController(IAuthenticateService authenticateServcie)
        {
            _authenticateServcie = authenticateServcie;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateServcie.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}