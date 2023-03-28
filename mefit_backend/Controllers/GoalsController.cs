using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.Models.DTO.Goal;
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

    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly IMapper _mapper;

        public GoalsController(IGoalService goalService, IMapper mapper)
        {
            _goalService = goalService;
            _mapper = mapper;
        }


        /// <summary>
        /// Get Goal By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Put goal by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putGoalDTO"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Post a Goal by Id
        /// </summary>
        /// <param name="createGoalDTO"></param>
        /// <returns></returns>
        [HttpPost("goal")]
        public async Task<ActionResult<Goal>> PostGoal(CreateGoalDTO createGoalDTO)
        {
            var goal = _mapper.Map<Goal>(createGoalDTO);
            await _goalService.CreateGoal(goal);
            return CreatedAtAction(nameof(GetGoal), new { id = goal.Id }, goal);
        }

        /// <summary>
        /// Delete goal by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get goal by profile Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("goals/profile/{id}")]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoalsByProfileId(string id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GetGoalDTO>>(await _goalService.GetGoalsByProfileId(id)));
            }
            catch (GoalNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
    }
}
