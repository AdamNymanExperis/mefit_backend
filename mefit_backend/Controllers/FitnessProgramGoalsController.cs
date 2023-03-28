using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.models.DTO.FitnessProgramGoalDtos;
using mefit_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Roles = "USER")]

    public class FitnessProgramGoalsController : ControllerBase
    {
        private readonly IFitnessProgramGoalService _fitnessProgramGoalService;
        private readonly IMapper _mapper;

        public FitnessProgramGoalsController(IFitnessProgramGoalService FitnessProgramGoalService, IMapper mapper)
        {
            _fitnessProgramGoalService = FitnessProgramGoalService;
            _mapper = mapper;

        }
        /// <summary>
        /// Get FitnessProgram Goal By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("fitnessprogramgoal/{id}")]
        public async Task<ActionResult<GetFitnessProgramGoalDTO>> GetFitnessProgramGoal(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetFitnessProgramGoalDTO>(await _fitnessProgramGoalService.GetFitnessProgramGoalById(id)));
            }
            catch (FitnessProgramGoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Put FitnessProgramGoal by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putFitnessProgramGoalDTO"></param>
        /// <returns></returns>
        [HttpPut("fitnessprogramgoal/{id}")]
        public async Task<IActionResult> PutFitnessProgramGoal(int id, PutFitnessProgramGoalDTO putFitnessProgramGoalDTO)
        {
            if (id != putFitnessProgramGoalDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                FitnessProgramGoal FitnessProgramGoalDomain = _mapper.Map<FitnessProgramGoal>(putFitnessProgramGoalDTO);
                await _fitnessProgramGoalService.UpdateFitnessProgramGoal(FitnessProgramGoalDomain);
            }
            catch (FitnessProgramGoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }

        /// <summary>
        /// Post a FitnessProgramGoal
        /// </summary>
        /// <param name="postFitnessProgramGoalDTO"></param>
        /// <returns></returns>
        [HttpPost("fitnessprogramgoal")]
        public async Task<ActionResult<FitnessProgramGoal>> PostFitnessProgramGoal(PostFitnessProgramGoalDTO postFitnessProgramGoalDTO)
        {
            var FitnessProgramGoal = _mapper.Map<FitnessProgramGoal>(postFitnessProgramGoalDTO);
            await _fitnessProgramGoalService.CreateFitnessProgramGoal(FitnessProgramGoal);
            return CreatedAtAction(nameof(GetFitnessProgramGoal), new { id = FitnessProgramGoal.Id }, FitnessProgramGoal);
        }

        /// <summary>
        /// Delete a FitnessprogramGoal by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("fitnessprogramgoal/{id}")]
        public async Task<IActionResult> DeleteFitnessProgramGoal(int id)
        {
            try
            {
                await _fitnessProgramGoalService.DeleteFitnessProgramGoal(id);
            }
            catch (FitnessProgramGoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

    }
}
