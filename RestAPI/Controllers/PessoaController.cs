using Microsoft.AspNetCore.Mvc;
using RestAPI.Model;
using RestAPI.Servicos;

namespace RestAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase {

        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaService _pessoaServico;

        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaServico) {
            _logger = logger;
            _pessoaServico = pessoaServico;
        }

        [HttpGet]
        public IActionResult ListarTodos() {

            return Ok(_pessoaServico.ListarTodasPessoas());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id) {
            var pessoa = _pessoaServico.ProcurarPorId(id);
            if(pessoa == null) {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult CriarPessoa([FromBody] Pessoa pessoa) {
            if(pessoa == null) {    
                return BadRequest();
            }
            return Ok(_pessoaServico.CriarPessoa(pessoa));
        }

        [HttpPut]
        public IActionResult AtualizarPessoa([FromBody] Pessoa pessoa) {
            if(pessoa == null) {
                return BadRequest();
            }
            return Ok(_pessoaServico.AtualizarPessoa(pessoa));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(int id) {
            if(id == null) {
                return BadRequest();
            }
            _pessoaServico.DeletarPessoa(id);
            return NoContent();
        }
    }
}