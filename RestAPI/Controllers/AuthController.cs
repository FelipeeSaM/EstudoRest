using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Business;
using RestAPI.Data.DTO;
using RestAPI.Model;

namespace RestAPI.Controllers {
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness) {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UsersDTO user) {
            if(user == null) return BadRequest("Credenciais invalidas");
            var token = _loginBusiness.ValidateCredentials(user);
            if(token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenDTO tokenDto) {
            if(tokenDto == null) return BadRequest("Credenciais invalidas");
            var token = _loginBusiness.ValidateCredentials(tokenDto);
            if(token == null) return BadRequest("Credenciais invalidas");
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        public IActionResult Revoke() {
            var userName = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(userName);
            if(!result) return BadRequest("Credenciais invalidas.");
            return NoContent();
        }
    }
}
