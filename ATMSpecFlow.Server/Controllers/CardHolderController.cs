using ATMSpecFlow.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSpecFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardHolderController : ControllerBase
    {
        ICardHolderRepo _cardHolderRepo;

        public CardHolderController(ICardHolderRepo cardHolderRepo)
        {
            _cardHolderRepo = cardHolderRepo;
        }


        [HttpGet]
        public IActionResult GetCardHolder(string cardNumber)
        {
            var cardHolder = _cardHolderRepo.GetCardHolderInfo(cardNumber);
            if (cardHolder == null)
            {
                return NoContent();
            }
            return Ok(cardHolder);

        }

        [HttpGet]
        public IActionResult GetBalance(CardHolder cardHolder)
        {
            var result = _cardHolderRepo.GetBalanceForCardHolder(cardHolder);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCardNumber(CardHolder cardHolder)
        {
            if (cardHolder is null)
            {
                return NoContent();
            }
            else
            {
                try
                {
                    _cardHolderRepo.UpdateCardHolderCardNumber(cardHolder);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdatePinNumber(CardHolder cardHolder)
        {
            if (cardHolder is null)
            {
                return NoContent();
            }
            else
            {
                try
                {
                    _cardHolderRepo.UpdateCardHolderPinNumber(cardHolder);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdateLastName(CardHolder cardHolder, string lastName)
        {
            if (cardHolder is null || lastName is null)
            {
                return NoContent();
            }
            else
            {
                try
                {
                    _cardHolderRepo.UpdateCardHolderLastName(cardHolder, lastName);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
    }
}
