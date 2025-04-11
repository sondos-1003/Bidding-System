using Microsoft.AspNetCore.Mvc;
using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntitiesTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IBidService _bidService;

        // Inject IBidService into the controller
        public BidsController(IBidService bidService)
        {
            _bidService = bidService;
        }

        // POST: api/bids/submit
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBid([FromBody] Bid bid)
        {
            if (bid == null)
            {
                return BadRequest("Bid data is required.");
            }

            var submittedBid = await _bidService.SubmitBidAsync(bid);
            if (submittedBid == null)
            {
                return BadRequest("Bid submission failed.");
            }

            return CreatedAtAction(nameof(GetBidById), new { id = submittedBid.Id }, submittedBid);
        }

        // GET: api/bids/tender/{tenderId}
        [HttpGet("tender/{tenderId}")]
        public async Task<IActionResult> GetBidsByTenderId(Guid tenderId)
        {
            var bids = await _bidService.GetBidsForTenderAsync(tenderId);
            if (bids == null || bids.Count == 0)
            {
                return NotFound();
            }

            return Ok(bids);
        }

        // GET: api/bids/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBidById(Guid id)
        {
            var bid = await _bidService.GetByIdAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }
    }
}
