using Microsoft.AspNetCore.Mvc;
using EntitiesTest.Application.Services;
using EntitiesTest.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EntitiesTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly TenderService _tenderService;

        // Inject TenderService into the controller
        public TendersController(TenderService tenderService)
        {
            _tenderService = tenderService;
        }

        // POST: api/tenders/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateTender([FromBody] Tender tender)
        {
            if (tender == null)
            {
                return BadRequest("Tender data is required.");
            }

            var createdTender = await _tenderService.CreateTenderAsync(tender);
            if (createdTender == null)
            {
                return BadRequest("Tender creation failed.");
            }

            return CreatedAtAction(nameof(GetTenderById), new { id = createdTender.TenderId }, createdTender);
        }

        // GET: api/tenders
        [HttpGet]
        

        // GET: api/tenders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenderById(int id)
        {
            

            return Ok();
        }

        // Additional actions like updating or deleting tenders can be added here
    }
}
