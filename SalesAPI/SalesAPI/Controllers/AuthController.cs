using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data.DTO;
using SalesAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections;
using System.Collections.Generic;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("sigin")]
        [SwaggerOperation(Summary = "Login", Description = "Do Login and return credential to Bearer Authentication")]
        [SwaggerResponse(200, "Success", typeof(TokenDTO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Signin([FromBody] AuthDTO user)
        {
            if (user == null) return BadRequest("Invalid Request!");
            TokenDTO token = _loginService.ValidateCredentials(user);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

    }
}
