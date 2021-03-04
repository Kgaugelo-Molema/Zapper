using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zapper.Payment.Api.Entities;
using Zapper.Payment.Api.Models;

namespace Zapper.Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly TransactionContext _context;

        public PaymentsController(ILogger<PaymentsController> logger, TransactionContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Transaction>> Create(Transaction transaction)
        {
            _logger.LogInformation("Creating new transaction");
            transaction.Amount = Math.Min(transaction.Amount, 5000);
            if (!transaction.Valid())
            {
                const string amountError = "Maximum amount of R5000.00 allowed";
                _logger.LogInformation(amountError);
                return Ok(amountError);
            }

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("{statusId}/{startDate}/{endData}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(Status statusId, DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation("Fetching transactions");
            var transactions = _context.Transactions.Where(transaction => transaction.StatusId == statusId && transaction.TransactionUtcDate >= startDate && transaction.TransactionUtcDate <= endDate);
            return Ok(transactions);
        }
    }
}
