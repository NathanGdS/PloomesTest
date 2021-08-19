using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data.DTO;
using SalesAPI.Services;
using System;
using System.Collections.Generic;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _context;


        public ProductController(IProductService context)
        {
            this._context = context;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<ProductDTO>))]
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
        [ProducesResponseType((200), Type = typeof(ProductDTO))]
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
        [ProducesResponseType((200), Type = typeof(ProductDTO))]
        [ProducesResponseType((400))]
        public IActionResult Post([FromBody] ProductDTO product)
        {

            try
            {
                return Ok(_context.Create(product));
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ProductDTO))]
        [ProducesResponseType((400))]
        public IActionResult Put([FromBody] ProductDTO product)
        {
            if (product == null) return BadRequest("Invalid Input!");
            return Ok(_context.Update(product));

        }

        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((404))]
        public IActionResult Delete(long id)
        {
            ProductDTO result = _context.FindByID(id);
            if (result == null) return NotFound("Invalid Id!");
           _context.Delete(id);
            return NoContent();
        }
    }
}
