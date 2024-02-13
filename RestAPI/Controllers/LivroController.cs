using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Model;
using RestAPI.Business;

namespace RestAPI.Controllers {
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivroController : ControllerBase {

        private readonly ILogger<LivroController> _logger;
        private readonly ILivroBusiness _livroBusiness;

        public LivroController(ILogger<LivroController> logger, ILivroBusiness livroBusiness) {
            _logger = logger;
            _livroBusiness = livroBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Livros>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult ListarTodos() {

            return Ok(_livroBusiness.BuscarTodosLivros());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Livros))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult ListarPorId(int id) {
            var Livro = _livroBusiness.BuscarLivroPorId(id);
            if(Livro == null) {
                return NotFound();
            }
            return Ok(Livro);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Livros))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult CriarLivro([FromBody] Livros Livro) {
            if(Livro == null) {    
                return BadRequest();
            }
            return Ok(_livroBusiness.AdicionarLivro(Livro));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Livros))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult AtualizarLivro([FromBody] Livros Livro) {
            if(Livro == null) {
                return BadRequest();
            }
            return Ok(_livroBusiness.AtualizarLivro(Livro));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult DeletarLivro(int id) {
            if(id == null) {
                return BadRequest();
            }
            _livroBusiness.DeletarLivro(id);
            return NoContent();
        }
    }
}