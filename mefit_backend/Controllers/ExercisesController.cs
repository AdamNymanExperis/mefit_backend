using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.models.DTO.ExerciseDtos;
using mefit_backend.Service;
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

    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        
        /// <summary>
        /// Gets all exercises and returns an IEnumerable of DTOs.
        /// </summary>
        /// <returns></returns>
        [HttpGet("exercises")]

        public async Task<ActionResult<IEnumerable<GetExerciseDTO>>> GetExercises()
        {
            //return Ok(await _exerciseService.GetExercises());
            return Ok(_mapper.Map<IEnumerable<GetExerciseDTO>>(await _exerciseService.GetExercises()));
        }

        /// <summary>
        /// Get Exercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// Put an exercise by a contributor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exerciseDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
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

        /// <summary>
        /// Posts a exercise by a contributor.
        /// </summary>
        /// <param name="exerciseDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPost("exercise")]
        public async Task<ActionResult<Exercise>> PostExercise(PostExerciseDTO exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);

            await _exerciseService.CreateExercise(exercise);

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        /// <summary>
        /// Deletes a exercise by a contributor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
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

        /// <summary>
        /// Put a impairment connected to a exercise.
        /// </summary>
        /// <param name="impairmentIds"></param>
        /// <param name="exerciseId"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPut("exercise/{exerciseId}/impairments")]
        public async Task<IActionResult> PutImpairmentsInExercise(int[] impairmentIds, int exerciseId)
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
