using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mefit_backend.models;
using mefit_backend.models.domain;
using System.Net.Mime;
using AutoMapper;
using mefit_backend.Services;
using mefit_backend.models.DTO.ExerciseDtos;
using mefit_backend.Models.dto.FitnessProgramDtos;
using mefit_backend.Exceptions;
using mefit_backend.Models.DTO.Goal;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FitnessProgramController : ControllerBase
    {
        private readonly IFitnessProgramService _fitnessProgramService;
        private readonly IMapper _mapper;

        public FitnessProgramController(IFitnessProgramService fitnessService, IMapper mapper)
        {
            _fitnessProgramService = fitnessService;
            _mapper = mapper;
        }

        // GET: api/FitnessPrograms
        [HttpGet("fitnessprograms")]
        public async Task<ActionResult<IEnumerable<GetFitnessProgramDTO>>> GetFitnessPrograms()
        {
            return Ok(_mapper.Map<IEnumerable<GetFitnessProgramDTO>>(await _fitnessProgramService.GetFitnessProgram()));
        }

        // GET: api/FitnessPrograms/5
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

        // PUT: api/FitnessPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/FitnessPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("fitnessprogram")]
        public async Task<ActionResult<FitnessProgram>> PostFitnessProgram(PostFitnessProgramDTO postFitnessProgramDTO)
        {
            var fitnessProgram = _mapper.Map<FitnessProgram>(postFitnessProgramDTO);
            await _fitnessProgramService.CreateFitnessProgram(fitnessProgram);
            return CreatedAtAction(nameof(GetFitnessProgram), new { id = fitnessProgram.Id }, fitnessProgram);
        }

        // DELETE: api/FitnessPrograms/5
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
