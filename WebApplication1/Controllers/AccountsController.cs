using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController: ControllerBase
    {
        // Controller is a combination of actions
        //Specify route in controller


        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() {
            return Ok(AccountDbContext.Current.Accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id) {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == id);
            if (account is null) {
                return BadRequest();
            }
            return Ok(account);

        }

        /*
        [HttpGet("data")]
        public IActionResult GetData() {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok();
        } */
    }
}
