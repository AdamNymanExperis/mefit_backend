using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.Models.DTO.ProfileDtos;
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

    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfilesController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<GetProfileDTO>> GetProfile(string id)
        {
            try
            {
                return Ok(_mapper.Map<GetProfileDTO>(await _profileService.GetProfileById(id)));
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
        /// Put profile by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putProfileDto"></param>
        /// <returns></returns>
        [HttpPut("profile/{id}")]
        public async Task<IActionResult> PutProfile(int id, PutProfileDTO putProfileDto)
        {
            if (id != putProfileDto.Id)
            {
                return BadRequest();
            }

            try
            {
                models.domain.Profile profileDomain = _mapper.Map<models.domain.Profile>(putProfileDto);
                await _profileService.UpdateProfile(profileDomain);
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
        /// post a profile
        /// </summary>
        /// <param name="createProfileDto"></param>
        /// <returns></returns>
        [HttpPost("profile")]
        public async Task<ActionResult<models.domain.Profile>> PostProfile(CreateProfileDTO createProfileDto)
        {
            var profile = _mapper.Map<models.domain.Profile>(createProfileDto);
            await _profileService.CreateProfile(profile);
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        /// <summary>
        /// Delete profile by id only user with ADMIN role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("profile/{id}")]
        public async Task<IActionResult> DeleteProfile(string id)
        {
            try
            {
                await _profileService.DeleteProfile(id);
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
        /// Put Impairment in Profile
        /// </summary>
        /// <param name="impairmentIds"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpPut("profile/{profileId}/impairments")]
        public async Task<IActionResult> PutImpairmentsInProfile(int[] impairmentIds, string profileId)
        {
            try
            {
                await _profileService.UpdateImpairmentsInProfile(impairmentIds, profileId);
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
