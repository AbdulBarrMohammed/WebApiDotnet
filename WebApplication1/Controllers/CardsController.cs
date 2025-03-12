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

        [HttpGet("{cardId}", Name ="GetCard")]
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


        [HttpPost] //Create new resource
        public ActionResult<Card> CreateCard(int accountId, [FromBody] CreateCard createCard)
        {
    
            //First check if account exists
            // check if number exists in cards
            // if it exists create a card
            // add it to the given account's cards list
            // return response
            var account = AccountDbContext.Current.Accounts.FirstOrDefault( x => x.Id == accountId);
            if (account is null) {
                return BadRequest();
            }

            var card = account.Cards.FirstOrDefault(x => x.Number == createCard.Number);
            if (card is null) {
                return BadRequest();
            }

            int id = account.Cards.OrderByDescending( x => x.Id).First().Id;

            Card _card = new Card() {
                ExpireDate = createCard.ExpireDate,
                Number = createCard.Number,
                HolderName = createCard.HolderName,
                Id = ++id

            };

            account.Cards.Add(_card);
            return CreatedAtRoute("GetCard", new {accountId, cardId = _card.Id}, _card);


        }

        [HttpPut("{cardId}")] //allows update
        public ActionResult<Card> UpdateCard(int accountId, int cardId, UpdateCard updateCard)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault( x => x.Id == accountId);
            if (account is null) {
                return BadRequest();
            }

            var card = account.Cards.FirstOrDefault(x => x.Id == cardId);
            if (card is null) {
                return BadRequest();
            }

            card.Number = updateCard.Number;
            card.ExpireDate = updateCard.ExpireDate;
            card.HolderName = updateCard.HolderName;
            return NoContent();
        }
    }
}
