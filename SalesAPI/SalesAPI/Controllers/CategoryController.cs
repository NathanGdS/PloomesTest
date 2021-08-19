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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _context;

        public CategoryController(ICategoryService context)
        {
            this._context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Return all Categories")]
        [ProducesResponseType((200), Type = typeof(List<CategoryDTO>))]
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
        [SwaggerOperation(Summary = "Return a specific Category by Id")]
        [ProducesResponseType((200), Type = typeof(CategoryDTO))]
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
        [SwaggerOperation(Summary = "Create a new Category")]
        [ProducesResponseType((200), Type = typeof(CategoryDTO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] CategoryDTO category)
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
        [SwaggerOperation(Summary = "Update an existing Category")]
        [ProducesResponseType((200), Type = typeof(Product))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Put([FromBody] CategoryDTO categoryUpdated)
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
        [SwaggerOperation(Summary = "Delete an existing Category")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((404))]
        public IActionResult Delete(long id)
        {
            CategoryDTO result = _context.FindByID(id);
            if (result == null) return NotFound("Invalid Id!");

           _context.Delete(id);
            return NoContent();

        }
    }
}
