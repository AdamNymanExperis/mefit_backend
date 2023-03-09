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
using mefit_backend.Services;
using System.Net.Mime;
using mefit_backend.Exceptions;

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

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET: api/Profiles/5
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            try
            {
                return Ok(await _profileService.GetProfileById(id));
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
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            try
            {
              
                await _profileService.UpdateProfile(profile);
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
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            await _profileService.CreateProfile(profile);
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("profile/{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
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
    }
}
