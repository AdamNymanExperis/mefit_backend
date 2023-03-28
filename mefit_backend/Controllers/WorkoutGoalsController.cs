using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.models.DTO.WorkoutGoalDtos;
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

    public class WorkoutGoalsController : ControllerBase
    {
        private readonly IWorkoutGoalService _workoutGoalService;
        private readonly IMapper _mapper;

        public WorkoutGoalsController(IWorkoutGoalService WorkoutGoalService, IMapper mapper)
        {
            _workoutGoalService = WorkoutGoalService;
            _mapper = mapper;

        }
        /// <summary>
        /// Get WorkoutGoal By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Put WorkoutGoal By id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putWorkoutGoalDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Post WorkoutGoal
        /// </summary>
        /// <param name="postWorkoutGoalDTO"></param>
        /// <returns></returns>
        [HttpPost("workoutgoal")]
        public async Task<ActionResult<WorkoutGoal>> PostWorkoutGoal(PostWorkoutGoalDTO postWorkoutGoalDTO)
        {
            var WorkoutGoal = _mapper.Map<WorkoutGoal>(postWorkoutGoalDTO);
            await _workoutGoalService.CreateWorkoutGoal(WorkoutGoal);
            return CreatedAtAction(nameof(GetWorkoutGoal), new { id = WorkoutGoal.Id }, WorkoutGoal);
        }

        /// <summary>
        /// Delete WorkoutGoal By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
