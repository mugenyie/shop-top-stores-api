using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalina.Core.Interfaces;
using catalina.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalina.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult PostUser(UserPostVM user)
        {
            try
            {
                var result = _userService.PostUser(user);
                return Ok(result);
            }catch(Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}