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
    public class RatioConfigController : ControllerBase
    {

        private readonly ILogger<RatioConfigController> _logger;

        public RatioConfigController(ILogger<RatioConfigController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Get()
        {
            var ratioConfigDA = new RatioConfigDataAccess();
            var data = ratioConfigDA.GetCurrentData();
            return Ok(data);
        }

        [HttpGet]
        [Route("[controller]/{value}")]
        public IActionResult Post([FromRoute] double value)
        {
            var model = new RatioConfigModel()
            {
                RatioValue = value
            };

            var ratioConfigDA = new RatioConfigDataAccess();
            ratioConfigDA.ChangeValue(model);
            return Ok("Done");
        }
    }
}
