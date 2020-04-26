using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoyaltyCard.Data;
using LoyaltyCard.Logic;

namespace LoyaltyCard.WebAPI.Controllers
{
    [ApiController]
    public class TransactionProcessController : ControllerBase
    {

        private readonly ILogger<TransactionProcessController> _logger;
        private readonly ProcessTransactionLogic _processTransactionLogic;
        public TransactionProcessController(ILogger<TransactionProcessController> logger)
        {
            _logger = logger;
            _processTransactionLogic = new ProcessTransactionLogic();
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Process()
        {
            _processTransactionLogic.ToProcessingTransaction();
            _processTransactionLogic.ProcessTransaction();
            return Ok("Done");
        }
    }
}
