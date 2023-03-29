using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.Models.dto.WorkoutExerciseDtos;
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

    public class WorkoutExercisesController : ControllerBase
    {
        private readonly IWorkoutExerciseService _workoutExerciseService;
        private readonly IMapper _mapper;

        public WorkoutExercisesController(IWorkoutExerciseService workoutExerciseService, IMapper mapper)
        {
            _workoutExerciseService = workoutExerciseService;
            _mapper = mapper;

        }
        /// <summary>
        /// Get WorkoutExercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("workoutexercise/{id}")]
        public async Task<ActionResult<GetWorkoutExerciseDTO>> GetWorkoutExercise(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetWorkoutExerciseDTO>(await _workoutExerciseService.GetWorkoutExerciseById(id)));
            }
            catch (WorkoutExerciseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Put WorkoutExercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putWorkoutExerciseDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPut("workoutexercise/{id}")]
        public async Task<IActionResult> PutWorkoutExercise(int id, PutWorkoutExerciseDTO putWorkoutExerciseDTO)
        {
            if (id != putWorkoutExerciseDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                WorkoutExercise workoutExerciseDomain = _mapper.Map<WorkoutExercise>(putWorkoutExerciseDTO);
                await _workoutExerciseService.UpdateWorkoutExercise(workoutExerciseDomain);
            }
            catch (WorkoutExerciseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }

        /// <summary>
        /// Post WorkoutExercise Only for user with Contributor Role
        /// </summary>
        /// <param name="postWorkoutExerciseDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPost("workoutexercise")]
        public async Task<ActionResult<WorkoutExercise>> PostWorkoutExercise(PostWorkoutExerciseDTO postWorkoutExerciseDTO)
        {
            var workoutExercise = _mapper.Map<WorkoutExercise>(postWorkoutExerciseDTO);
            await _workoutExerciseService.CreateWorkoutExercise(workoutExercise);
            return CreatedAtAction(nameof(GetWorkoutExercise), new { id = workoutExercise.Id }, workoutExercise);
        }

        /// <summary>
        /// Delete WorkoutExercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpDelete("workoutexercise/{id}")]
        public async Task<IActionResult> DeleteWorkoutExercise(int id)
        {
            try
            {
                await _workoutExerciseService.DeleteWorkoutExercise(id);
            }
            catch (WorkoutExerciseNotFoundException ex)
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
