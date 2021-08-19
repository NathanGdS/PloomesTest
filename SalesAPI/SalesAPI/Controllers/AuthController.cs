using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data.DTO;
using SalesAPI.Services;

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
        public IActionResult Signin([FromBody] AuthDTO user)
        {
            if (user == null) return BadRequest("Invalid Request!");
            TokenDTO token = _loginService.ValidateCredentials(user);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

    }
}
