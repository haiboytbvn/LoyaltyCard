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
    public class TransactionController : ControllerBase
    {

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[controller]/{value}")]
        public IActionResult Post([FromBody] TransactionModel dataViewModel)
        {
            var model = dataViewModel;
            model.ID = DateTime.UtcNow.Ticks.ToString();
            model.CreatedOn = DateTime.UtcNow;
            model.ModifiedOn = DateTime.UtcNow;
            model.TransactionState = TransactionState.PROCESSING;

            var transactionDA = new TransactionDataAccess();
            transactionDA.SaveToDatabase(model);
            return Ok("Done");
        }
    }
}
