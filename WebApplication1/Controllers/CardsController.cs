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
    [Route("api/accounts/{accountId}/[controller]")]
    public class CardsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ICollection<Card>> GetCards(int accountId) {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault( x => x.Id == accountId);
            if (account is null) {
                return BadRequest();
            }

            return Ok(account.Cards);
        }

        [HttpGet("{cardId}")]
        public ActionResult<Card> GetCard(int accountId, int cardId)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault( x => x.Id == accountId);
            if (account is null) {
                return BadRequest();
            }

            var card = account.Cards.FirstOrDefault(x => x.Id == cardId);
            if (card is null) {
                return BadRequest();
            }

            return Ok(card);
        }
    }
}
