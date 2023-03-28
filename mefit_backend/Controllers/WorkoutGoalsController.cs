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
using mefit_backend.models.DTO.WorkoutGoalDtos;
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

    public class WorkoutGoalsController : ControllerBase
    {
        private readonly IWorkoutGoalService _workoutGoalService;
        private readonly IMapper _mapper;

        public WorkoutGoalsController(IWorkoutGoalService WorkoutGoalService, IMapper mapper)
        {
            _workoutGoalService = WorkoutGoalService;
            _mapper = mapper;

        }
        // GET: api/WorkoutGoals/5
        [HttpGet("workoutgoal/{id}")]
        public async Task<ActionResult<GetWorkoutGoalDTO>> GetWorkoutGoal(int id)
        {
                try
                {
                    return Ok(_mapper.Map<GetWorkoutGoalDTO>(await _workoutGoalService.GetWorkoutGoalById(id)));
                }
                catch (WorkoutGoalNotFoundException ex)
                {
                    return NotFound(new ProblemDetails
                    {
                        Detail = ex.Message
                    });
                }
            }

        // PUT: api/WorkoutGoals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("workoutgoal/{id}")]
        public async Task<IActionResult> PutWorkoutGoal(int id, PutWorkoutGoalDTO putWorkoutGoalDTO)
        {
            if (id != putWorkoutGoalDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                WorkoutGoal WorkoutGoalDomain = _mapper.Map<WorkoutGoal>(putWorkoutGoalDTO);
                await _workoutGoalService.UpdateWorkoutGoal(WorkoutGoalDomain);
            }
            catch (WorkoutGoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }

        // POST: api/WorkoutGoals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost ("workoutgoal")]
        public async Task<ActionResult<WorkoutGoal>> PostWorkoutGoal(PostWorkoutGoalDTO postWorkoutGoalDTO)
        {
            var WorkoutGoal = _mapper.Map<WorkoutGoal>(postWorkoutGoalDTO);
            await _workoutGoalService.CreateWorkoutGoal(WorkoutGoal);
            return CreatedAtAction(nameof(GetWorkoutGoal), new { id = WorkoutGoal.Id }, WorkoutGoal);
        }

        // DELETE: api/WorkoutGoals/5
        [HttpDelete("workoutgoal/{id}")]
        public async Task<IActionResult> DeleteWorkoutGoal(int id)
        {
            try
            {
                await _workoutGoalService.DeleteWorkoutGoal(id);
            }
            catch (WorkoutGoalNotFoundException ex)
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
