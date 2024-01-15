using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase {

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger) {
            _logger = logger;
        }

        [HttpGet("somar/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Somar(string primeiroNumero, string segundoNumero) {

            return BadRequest("Alguma entrada inválida.");
        }

    }
}