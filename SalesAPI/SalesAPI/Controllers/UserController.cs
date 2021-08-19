using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data.DTO;
using SalesAPI.Services;
using System;
using System.Collections.Generic;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _context;

        public UserController(IUserService context)
        {
            this._context = context;
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UserDTO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] UserDTO user)
        {
            try
            {
                return Ok(_context.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }
        
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<UserDTO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UserDTO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((404))]
        public IActionResult Get(long id)
        {
            try
            {
                UserDTO result = _context.FindByID(id);
                if (result == null) return NotFound("Invalid Id!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((404))]
        public IActionResult Delete(long id)
        {
            UserDTO result = _context.FindByID(id);
            if (result == null) return NotFound("Invalid Id!");

            _context.Delete(id);
            return NoContent();

        }
    }
}
