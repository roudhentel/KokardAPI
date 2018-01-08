using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CardWebAPI.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Card")]
    public class CardController : Controller
    {
        // Variable Declaration
        public CardService cardSvc;

        public CardController()
        {
            // Variable Initialization
            cardSvc = new CardService();
        }

        [HttpGet]
        [Route("SampleGet")]
        public string SampleGet(string str)
        {
            return str;
        }

        // api/Card/ActivateCard
        [HttpPost]
        [Route("ActivateCard")]
        public ActionResult ActivateCard([FromBody]Dictionary<string, string> body)
        {
            var response = cardSvc.ActivateCard(body["cardNumber"].ToString());
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("GetCardStatus")]
        public ActionResult GetCardStatus(string cardNumber)
        {
            var response = cardSvc.GetCardStatus(cardNumber);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}
