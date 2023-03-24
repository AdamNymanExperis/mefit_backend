using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mefit_backend.models;
using mefit_backend.models.domain;
using AutoMapper;
using mefit_backend.Services;
using mefit_backend.Exceptions;
using mefit_backend.Models.DTO.WorkoutDtos;
using mefit_backend.models.DTO.ImpairmentDtos;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
       
        private readonly IWorkoutService _workoutService;
        private readonly IMapper _mapper;

        public WorkoutsController(IWorkoutService workoutService, IMapper mapper)
        {
            _workoutService = workoutService;
            _mapper = mapper;
        }

        // GET: api/Impairments
        [HttpGet("workouts")]
        public async Task<ActionResult<IEnumerable<GetWorkoutDTO>>> GetWorkouts()
        {
            return Ok(_mapper.Map<IEnumerable<GetWorkoutDTO>>(await _workoutService.GetWorkouts()));
        }

        // GET: api/Workouts/5
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

        // POST: api/Workouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("workout")]
        public async Task<ActionResult<Workout>> PostWorkout(AddWorkoutDTO addWorkoutDto)
        {
            var workout = _mapper.Map<Workout>(addWorkoutDto);
            await _workoutService.AddWorkout(workout);
            return CreatedAtAction(nameof(GetWorkout), new { id = workout.Id }, workout);
        }

        // DELETE: api/Workouts/5
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

        // PUT: api/Workouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
