using Microsoft.AspNetCore.Mvc;
using mefit_backend.Services;
using System.Net.Mime;
using mefit_backend.Exceptions;
using mefit_backend.Models.DTO.ProfileDtos;
using AutoMapper;

namespace mefit_backend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfilesController(IProfileService profileService ,IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        // GET: api/Profiles/5
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

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("profile")]
        public async Task<ActionResult<models.domain.Profile>> PostProfile(CreateProfileDTO createProfileDto)
        {
            var profile = _mapper.Map<models.domain.Profile> (createProfileDto);
            await _profileService.CreateProfile(profile);
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
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

        [HttpPut("profile/{profileId}/impairments")]
        public async Task<IActionResult> PutImpairmentsInPorfile(int[] impairmentIds, string profileId)
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
