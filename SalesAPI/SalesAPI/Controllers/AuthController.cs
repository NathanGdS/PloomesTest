using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Route("refresh")]
        [SwaggerOperation(Summary = "Refresh Token", Description = "Use the old access and refresh token to generate valids acces_token and refresh token")]
        [SwaggerResponse(200, "Success", typeof(TokenDTO))]
        [ProducesResponseType((400))]
        public IActionResult Refresh([FromBody] RefreshDTO tokenDTO)
        {
            if (tokenDTO == null) return BadRequest("Invalid Token!");
            TokenDTO token = _loginService.ValidateCredentials(tokenDTO);
            if (token == null) return BadRequest("Invalid Token!");

            return Ok(token);
        }

        [HttpPost]
        [Route("revoke")]
        [Authorize("Bearer")]
        [SwaggerOperation(Summary = "Revoke Token")]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Revoke()
        { 

            string username = User.Identity.Name;
            bool result = _loginService.RevokeToken(username);

            if (!result) return BadRequest("Invalid Token!");

            return NoContent();
        }

    }
}
