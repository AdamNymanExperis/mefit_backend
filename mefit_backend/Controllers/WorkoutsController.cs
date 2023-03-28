using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.Models.DTO.WorkoutDtos;
using mefit_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize(Roles = "USER")]
    public class WorkoutsController : ControllerBase
    {

        private readonly IWorkoutService _workoutService;
        private readonly IMapper _mapper;

        public WorkoutsController(IWorkoutService workoutService, IMapper mapper)
        {
            _workoutService = workoutService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All WorkOuts
        /// </summary>
        /// <returns></returns>
        [HttpGet("workouts")]
        public async Task<ActionResult<IEnumerable<GetWorkoutDTO>>> GetWorkouts()
        {
            return Ok(_mapper.Map<IEnumerable<GetWorkoutDTO>>(await _workoutService.GetWorkouts()));
        }

        /// <summary>
        /// Get Workouts By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("workout/{id}")]
        public async Task<ActionResult<GetWorkoutDTO>> GetWorkout(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetWorkoutDTO>(await _workoutService.GetWorkoutById(id)));
            }
            catch (WorkoutNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Post Workout only by user With Contributor Role
        /// </summary>
        /// <param name="addWorkoutDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPost("workout")]
        public async Task<ActionResult<Workout>> PostWorkout(AddWorkoutDTO addWorkoutDto)
        {
            var workout = _mapper.Map<Workout>(addWorkoutDto);
            await _workoutService.AddWorkout(workout);
            return CreatedAtAction(nameof(GetWorkout), new { id = workout.Id }, workout);
        }

        /// <summary>
        /// Delete Workouts only by user With Contributor Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpDelete("workout/{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            try
            {
                await _workoutService.DeleteWorkout(id);
            }
            catch (WorkoutNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Put workout by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putWorkoutDTO"></param>
        /// <returns></returns>
        [HttpPut("workout/{id}")]
        public async Task<IActionResult> PutWorkout(int id, PutWorkoutDTO putWorkoutDTO)
        {
            if (id != putWorkoutDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                Workout domainWorkout = _mapper.Map<Workout>(putWorkoutDTO);
                await _workoutService.UpdateWorkout(domainWorkout);
            }
            catch (WorkoutNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Put WokroutExercises in Workout by workout Id only by user With Contributor Role
        /// </summary>
        /// <param name="workoutExercisesIds"></param>
        /// <param name="workoutId"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPut("workout/{workoutId}/exercise")]
        public async Task<IActionResult> PutWorkoutExercisesInWorkout(int[] workoutExercisesIds, int workoutId)
        {
            try
            {
                await _workoutService.UpdateWorkoutExercisesInWorkout(workoutExercisesIds, workoutId);
                return NoContent();
            }
            catch (ProfileNotFoundException ex)
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
