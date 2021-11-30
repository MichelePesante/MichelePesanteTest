using MichelePesanteTest.Entities;
using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MichelePesanteTest.Controllers
{
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthorizationService authService;

        public AuthenticationController(IAuthorizationService _authService)
        {
            authService = _authService;
        }

        [HttpPost("api/authenticate")]
        public ActionResult<User> Authenticate([FromBody] AuthorizationRequestModel authorizationRequest)
        {
            if (authorizationRequest == null)
                return BadRequest();

            var authentication = authService.Authenticate($"{authorizationRequest.Name}_{authorizationRequest.Id}", authorizationRequest.Secret);
            if (authentication == null)
                return Forbid();
            return Ok(authentication);
        }
    }
}
