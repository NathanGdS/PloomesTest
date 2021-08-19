using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data.DTO;
using SalesAPI.Model;
using SalesAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _context;

        public PurchaseController(IPurchaseService context)
        {
            this._context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Return all Purchases")]
        [ProducesResponseType((200), Type = typeof(List<PurchaseDTO>))]
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
        [SwaggerOperation(Summary = "Return an specific Purchase")]
        [ProducesResponseType((200), Type = typeof(PurchaseDTO))]
        [ProducesResponseType((400))]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_context.FindByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Make a new Purchase")]
        [ProducesResponseType((200), Type = typeof(PurchaseDTO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] PurchaseDTO category)
        {
            try
            {
                return Ok(_context.Create(category));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an Purchase")]
        [ProducesResponseType((200), Type = typeof(Purchase))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Put([FromBody] PurchaseDTO categoryUpdated)
        {
            try
            {
                return Ok(_context.Update(categoryUpdated));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete an Purchase")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((404))]
        public IActionResult Delete(long id)
        {
            PurchaseDTO result = _context.FindByID(id);
            if (result == null) return NotFound("Invalid Id!");

           _context.Delete(id);
            return NoContent();

        }
    }
}
