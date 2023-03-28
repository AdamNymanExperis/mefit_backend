using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models.domain;
using mefit_backend.models.DTO.ImpairmentDtos;
using mefit_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize(Roles = "USER")]
    public class ImpairmentsController : ControllerBase
    {
        private readonly IImpairmentService _impairmentService;
        private readonly IMapper _mapper;

        public ImpairmentsController(IImpairmentService impairmentService, IMapper mapper)
        {
            _impairmentService = impairmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Impairments
        /// </summary>
        /// <returns></returns>
        [HttpGet("impairments")]
        public async Task<ActionResult<IEnumerable<GetImpairmentDTO>>> GetImpairments()
        {
            return Ok(_mapper.Map<IEnumerable<GetImpairmentDTO>>(await _impairmentService.GetImpairments()));
        }

        /// <summary>
        /// Get Impairment by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("impairment/{id}")]
        public async Task<ActionResult<GetImpairmentDTO>> GetImpairment(int id)
        {
            try
            {
                return Ok(_mapper.Map<GetImpairmentDTO>(await _impairmentService.GetImpairmentById(id)));
            }
            catch (ImpairmentNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Put Impairment by id only Contributor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putImpairmentDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPut("impairment/{id}")]
        public async Task<IActionResult> PutImpairment(int id, PutImpairmentDTO putImpairmentDTO)
        {
            Impairment impairment = _mapper.Map<Impairment>(putImpairmentDTO);

            if (id != impairment.Id)
            {
                return BadRequest();
            }

            try
            {
                await _impairmentService.UpdateImpairment(impairment);
            }
            catch (ImpairmentNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Post impairment only by Contributor
        /// </summary>
        /// <param name="impairmentDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpPost("impairment")]
        public async Task<ActionResult<Impairment>> PostImpairment(PostImpairmentDTO impairmentDTO)
        {
            var impairment = _mapper.Map<Impairment>(impairmentDTO);

            await _impairmentService.CreateImpairment(impairment);

            return CreatedAtAction("GetImpairment", new { id = impairment.Id }, impairment);
        }

        /// <summary>
        /// delete impairment by id only user with contributor role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "CONTRIBUTOR")]
        [HttpDelete("impairment/{id}")]
        public async Task<IActionResult> DeleteImpairment(int id)
        {
            try
            {
                await _impairmentService.DeleteImpairment(id);
            }
            catch (ImpairmentNotFoundException ex)
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
