using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoyaltyCard.Data;

namespace LoyaltyCard.WebAPI.Controllers
{
    [ApiController]
  
    public class LoyaltyCardController : ControllerBase
    {
    
        private readonly ILogger<LoyaltyCardController> _logger;

        public LoyaltyCardController(ILogger<LoyaltyCardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Get()
        {
            var loyatyCardDA = new LoyaltyCardDataAccess();
            var allData = loyatyCardDA.LoadData();
            return Ok(allData);
        }

        [HttpGet]
        [Route("[controller]/{value}")]
        public IActionResult Post([FromRoute] string value)
        {
            var model = new LoyaltyCardModel()
            {
                ID = DateTime.UtcNow.Ticks.ToString(),
            };
            if (string.IsNullOrWhiteSpace(value))
            {
                model.Code = "LT" + model.ID;
            }

            model.Code = value.Substring(0,2).ToUpper() + model.ID;
            model.LoyaltyCartTypeId = 0;
            model.CreatedOn = DateTime.UtcNow;
            model.ModifiedOn = DateTime.UtcNow;

            var loyatyCardDA = new LoyaltyCardDataAccess();
            loyatyCardDA.SaveToDatabase(model);
            return Ok("Done");
        }
    }
}
