using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.Models.dto.FitnessProgramDtos;
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
    public class FitnessProgramController : ControllerBase
    {
        private readonly IFitnessProgramService _fitnessProgramService;
        private readonly IMapper _mapper;

        public FitnessProgramController(IFitnessProgramService fitnessService, IMapper mapper)
        {
            _fitnessProgramService = fitnessService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get fitnessProgram of DTOs 
        /// </summary>
        /// <returns></returns>
        [HttpGet("fitnessprograms")]
        public async Task<ActionResult<IEnumerable<GetFitnessProgramDTO>>> GetFitnessPrograms()
        {
            return Ok(_mapper.Map<IEnumerable<GetFitnessProgramDTO>>(await _fitnessProgramService.GetFitnessProgram()));
        }

        /// <summary>
        /// Gets a fitnessProgram by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("fitnessprogram/{id}")]
        public async Task<ActionResult<GetFitnessProgramDTO>> GetFitnessProgram(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetFitnessProgramDTO>(await _fitnessProgramService.GetFitnessProgramById(id)));
            }
            catch (FitnessProgramNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Put fitnessProgram by id for role contributor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putFitnessProgramDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPut("fitnessprogram/{id}")]
        public async Task<IActionResult> PutFitnessProgram(int id, PutFitnessProgramDTO putFitnessProgramDTO)
        {
            if (id != putFitnessProgramDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                FitnessProgram fitnessProgramDomain = _mapper.Map<FitnessProgram>(putFitnessProgramDTO);
                await _fitnessProgramService.UpdateFitnessProgram(fitnessProgramDomain);
            }
            catch (FitnessProgramNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }

        /// <summary>
        /// Post fitnessProgram by role contributor.
        /// </summary>
        /// <param name="postFitnessProgramDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPost("fitnessprogram")]
        public async Task<ActionResult<FitnessProgram>> PostFitnessProgram(PostFitnessProgramDTO postFitnessProgramDTO)
        {
            var fitnessProgram = _mapper.Map<FitnessProgram>(postFitnessProgramDTO);
            await _fitnessProgramService.CreateFitnessProgram(fitnessProgram);
            return CreatedAtAction(nameof(GetFitnessProgram), new { id = fitnessProgram.Id }, fitnessProgram);
        }

        /// <summary>
        /// Delete a fitnessProgram by id for role contributor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpDelete("fitnessprogram/{id}")]
        public async Task<IActionResult> DeleteFitnessProgram(int id)
        {
            try
            {
                await _fitnessProgramService.DeleteFitnessProgram(id);
            }
            catch (FitnessProgramNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Put a fitnessProgram for role contributor.
        /// </summary>
        /// <param name="workoutIds"></param>
        /// <param name="fitnessProgramId"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPut("fitnessprogram/{fitnessProgramId}/workouts")]
        public async Task<IActionResult> PutWorkoutsInFitnessProgram(int[] workoutIds, int fitnessProgramId)
        {
            try
            {
                await _fitnessProgramService.UpdateWorkoutsInFitnessProgram(workoutIds, fitnessProgramId);
                return NoContent();
            }
            catch (FitnessProgramNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message
                    }
                    );
            }
        }

    }
}
