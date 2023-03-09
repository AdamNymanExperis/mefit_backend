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
using AutoMapper;
using mefit_backend.Models.DTO.User;

namespace mefit_backend.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/User => 303 with logged in user


        // GET: api/Users/5
        //[Authorize]//(Roles = "USER")]
        [HttpGet("User/{id}")]
        public async Task<ActionResult<GetUserDTO>> GetUser(int id)
        {
            try
            { 
                return Ok(_mapper.Map<GetUserDTO>(await _userService.GetUserById(id)));
            }
            catch ( UserNotFoundException ex)
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
        public async Task<ActionResult<User>> PostUser(AddUserDTO addUserDTO)
        {
            var user = _mapper.Map<User>(addUserDTO);
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
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
       [HttpPut("User/{id}")]
       public async Task<IActionResult> PutUser(int id, PutUserDTO putUserDTO)
       {
            if (id != putUserDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                User domainUser = _mapper.Map<User>(putUserDTO);
                await _userService.UpdateUser(domainUser);
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

        // POST: api/User/5/update_password
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("User/{id}/update_password")]
        public async Task<ActionResult<User>> PostUserPassword(int id, string password)
        {
            //var password = _mapper.Map<User>(passwordDTO);
            await _userService.UpdateUserPassword(id, password);
            return NoContent();
        }
    }
}
