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
using mefit_backend.Models.dto.WorkoutExerciseDtos;
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

    public class WorkoutExercisesController : ControllerBase
    {
        private readonly IWorkoutExerciseService _workoutExerciseService;
        private readonly IMapper _mapper;

        public WorkoutExercisesController(IWorkoutExerciseService workoutExerciseService, IMapper mapper)
        {
            _workoutExerciseService = workoutExerciseService;
            _mapper = mapper;

        }
        // GET: api/WorkoutExercises/5
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

        // PUT: api/WorkoutExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/WorkoutExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPost ("workoutexercise")]
        public async Task<ActionResult<WorkoutExercise>> PostWorkoutExercise(PostWorkoutExerciseDTO postWorkoutExerciseDTO)
        {
            var workoutExercise = _mapper.Map<WorkoutExercise>(postWorkoutExerciseDTO);
            await _workoutExerciseService.CreateWorkoutExercise(workoutExercise);
            return CreatedAtAction(nameof(GetWorkoutExercise), new { id = workoutExercise.Id }, workoutExercise);
        }

        // DELETE: api/WorkoutExercises/5
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
