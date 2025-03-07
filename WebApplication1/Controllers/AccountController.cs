using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController: ControllerBase
    {
        // Controller is a combination of actions
        //Specify route in controller

        [HttpGet("api/accounts")]
        public string GetData() {
            return "simple string";
        }
    }
}
