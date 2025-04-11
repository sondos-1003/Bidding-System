using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EntitiesTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidDocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public BidDocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromBody] BidDocumentUploadDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid document data.");

            var result = await _documentService.UploadDocumentAsync(dto);
            return CreatedAtAction(nameof(GetByBidId), new { bidId = dto.BidId }, result);
        }

        [HttpGet("bid/{bidId}")]
        public async Task<IActionResult> GetByBidId(Guid bidId)
        {
            var docs = await _documentService.GetDocumentsByBidIdAsync(bidId);
            return Ok(docs);
        }
    }
}
