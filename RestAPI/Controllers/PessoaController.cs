using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Model;
using RestAPI.Business;
using Microsoft.AspNetCore.Authorization;

namespace RestAPI.Controllers {
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PessoaController : ControllerBase {

        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaBusiness _pessoaBusiness;

        public PessoaController(ILogger<PessoaController> logger, IPessoaBusiness pessoaBusiness) {
            _logger = logger;
            _pessoaBusiness = pessoaBusiness;
        }

        [HttpGet]
        public IActionResult ListarTodos() {

            return Ok(_pessoaBusiness.ListarTodasPessoas());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id) {
            var pessoa = _pessoaBusiness.ProcurarPorId(id);
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
            return Ok(_pessoaBusiness.CriarPessoa(pessoa));
        }

        [HttpPut]
        public IActionResult AtualizarPessoa([FromBody] Pessoa pessoa) {
            if(pessoa == null) {
                return BadRequest();
            }
            return Ok(_pessoaBusiness.AtualizarPessoa(pessoa));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchPessoa(long id) {
            var pessoa = _pessoaBusiness.AtivarOuDesativar(id);
            if(pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(int id) {
            if(id == null) {
                return BadRequest();
            }
            _pessoaBusiness.DeletarPessoa(id);
            return NoContent();
        }
    }
}