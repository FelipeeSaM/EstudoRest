using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Business;
using RestAPI.Model;

namespace RestAPI.Controllers {

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase {

        private readonly IArquivoBusiness _arquivoBusiness;

        public ArquivoController(IArquivoBusiness arquivo) {
            _arquivoBusiness = arquivo;
        }

        [HttpPost("uploadArquivo")]
        [Produces("application/json")]
        public async Task<IActionResult> SalvarUmArquivo([FromForm] IFormFile arquivoUpload) {
            Arquivo arquivo = await _arquivoBusiness.SalvarArquivoDisco(arquivoUpload);
            return new OkObjectResult(arquivo);
        }
    }
}
