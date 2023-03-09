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
using Microsoft.AspNetCore.Authorization;
using mefit_backend.Exceptions;

namespace mefit_backend.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users/5
        [Authorize]//(Roles = "USER")]
        [HttpGet("User/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                return Ok(await _userService.GetUserById(id));
            }
            catch ( Exception ex)//UserNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
       
       

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("User")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(user), new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        
       // PUT: api/Users/5
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPut("{id}")]
       public async Task<IActionResult> PutUser(int id, User user)
       {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userService.UpdateUser(user);
            }
            catch (UserNotFoundException ex)
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
