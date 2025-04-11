using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using EntitiesTest.DTOs;
using EntitiesTest.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using EntitiesTest.Application.Services.Interfaces;
using EntitiesTest.Application.Services.Interfaces;
namespace EntitiesTest.Controllers
{
    

    
        [ApiController]
        [Route("api/[controller]")]
        public class EvaluationController : ControllerBase
        {
            private readonly IEvaluationService _evaluationService;

            public EvaluationController(IEvaluationService evaluationService)
            {
                _evaluationService = evaluationService;
            }

            // GET: api/Evaluation
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Evaluation>>> GetAll()
            {
                var evaluations = await _evaluationService.GetAllEvaluationsAsync();
                return Ok(evaluations);
            }

            // GET: api/Evaluation/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<Evaluation>> GetById(Guid id)
            {
                var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
                if (evaluation == null)
                    return NotFound();

                return Ok(evaluation);
            }

            // POST: api/Evaluation
            [HttpPost]
            public async Task<ActionResult> Create([FromBody] EvaluationDto evaluationDto)
            {
                try
                {
                    await _evaluationService.CreateEvaluationAsync(evaluationDto);
                    return Ok(new { message = "Evaluation created successfully." });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { error = ex.Message });
                }
            }

            // PUT: api/Evaluation/{id}
            [HttpPut("{id}")]
            public async Task<ActionResult> Update(Guid id, [FromBody] EvaluationDto evaluationDto)
            {
                try
                {
                    await _evaluationService.UpdateEvaluationAsync(id, evaluationDto);
                    return Ok(new { message = "Evaluation updated successfully." });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { error = ex.Message });
                }
            }

            // DELETE: api/Evaluation/{id}
            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(Guid id)
            {
                try
                {
                    await _evaluationService.DeleteEvaluationAsync(id);
                    return Ok(new { message = "Evaluation deleted successfully." });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { error = ex.Message });
                }
            }
        }
    

}
