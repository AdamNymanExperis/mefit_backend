using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mefit_backend.models;
using mefit_backend.models.domain;
using mefit_backend.Service;
using mefit_backend.Exceptions;
using AutoMapper;
using mefit_backend.models.DTO.ExerciseDtos;
using System.Net.Mime;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;   
        }

        // GET: api/Exercises
        [HttpGet("exercise")]
        public async Task<ActionResult<IEnumerable<GetExerciseDTO>>> GetExercises()
        {
            //return Ok(await _exerciseService.GetExercises());
            return Ok(_mapper.Map<IEnumerable<GetExerciseDTO>>(await _exerciseService.GetExercises()));
        }

        // GET: api/Exercises/5
        [HttpGet("exercise/{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetExerciseDTO>(await _exerciseService.GetExerciseById(id)));
            }
            catch (ProfileNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("exercise/{id}")]
        public async Task<IActionResult> PutExercise(int id, PutExerciseDTO exerciseDTO)
        {
            Exercise exercise = _mapper.Map<Exercise>(exerciseDTO);

            if (id != exercise.Id)
            {
                return BadRequest();
            }

            try
            {
                await _exerciseService.UpdateExercise(exercise);
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

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("exercise")]
        public async Task<ActionResult<Exercise>> PostExercise(PostExerciseDTO exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);

            await _exerciseService.CreateExercise(exercise);

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("exercise/{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            try
            {
                await _exerciseService.DeleteExercise(id);
            }
            catch (ExerciseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        [HttpPut("exercise/{exerciseId}/impairments")]
        public async Task<IActionResult> PutImpairmentsInPorfile(int[] impairmentIds, int exerciseId)
        {
            try
            {
                await _exerciseService.UpdateImpairmentsInExercise(impairmentIds, exerciseId);
                return NoContent();
            }
            catch (ExerciseNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message
                    });
            }
        }
    }
}
