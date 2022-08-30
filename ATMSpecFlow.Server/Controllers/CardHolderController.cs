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
            try
            {
                var cardHolder = _cardHolderRepo.GetCardHolderInfo(cardNumber);
                if (cardHolder == null)
                {
                    return new NoContentResult();
                }
                return Ok(cardHolder);
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}
