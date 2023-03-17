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
using mefit_backend.Models.DTO.ProfileDtos;
using mefit_backend.Models.DTO.Goal;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly IMapper _mapper;

        public GoalsController(IGoalService goalService, IMapper mapper)
        {
            _goalService = goalService;
            _mapper = mapper;
        }


        // GET: api/Goals/5
        [HttpGet("goal/{id}")]
        public async Task<ActionResult<GetGoalDTO>> GetGoal(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetGoalDTO>(await _goalService.GetGoalById(id)));
            }
            catch (GoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // PUT: api/Goals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("goal/{id}")]
        public async Task<IActionResult> PutGoal(int id, PutGoalDTO putGoalDTO)
        {
            if (id != putGoalDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                Goal goalDomain = _mapper.Map<Goal>(putGoalDTO);
                await _goalService.UpdateGoal(goalDomain);
            }
            catch (ProfileNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }
        // POST: api/Goals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("goal")]
        public async Task<ActionResult<Goal>> PostGoal(CreateGoalDTO createGoalDTO)
        {
            var goal = _mapper.Map<Goal>(createGoalDTO);
            await _goalService.CreateGoal(goal);
            return CreatedAtAction(nameof(GetGoal), new { id = goal.Id }, goal);
        }

        // DELETE: api/Goals/5
        [HttpDelete("goal/{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            try
            {
                await _goalService.DeleteGoal(id);
            }
            catch (GoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        [HttpGet("goals/profile/{id}")]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoalsByProfileId(string id) 
        {
            try 
            {
                return Ok(_mapper.Map<IEnumerable<GetGoalDTO>>(await _goalService.GetGoalsByProfileId(id)));
            } catch (GoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
    }
}
