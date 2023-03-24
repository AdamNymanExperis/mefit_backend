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
using mefit_backend.Exceptions;
using mefit_backend.Models.DTO.Goal;
using mefit_backend.models.DTO.FitnessProgramGoalDtos;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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
        // GET: api/FitnessProgramGoals/5
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

        // PUT: api/FitnessProgramGoals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/FitnessProgramGoals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("fitnessprogramgoal")]
        public async Task<ActionResult<FitnessProgramGoal>> PostFitnessProgramGoal(PostFitnessProgramGoalDTO postFitnessProgramGoalDTO)
        {
            var FitnessProgramGoal = _mapper.Map<FitnessProgramGoal>(postFitnessProgramGoalDTO);
            await _fitnessProgramGoalService.CreateFitnessProgramGoal(FitnessProgramGoal);
            return CreatedAtAction(nameof(GetFitnessProgramGoal), new { id = FitnessProgramGoal.Id }, FitnessProgramGoal);
        }

        // DELETE: api/FitnessProgramGoals/5
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
