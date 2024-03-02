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

        [HttpPost("downloadArquivo/{nomearquivo}")]
        [Produces("application/octet-stream")]
        public async Task<IActionResult> BaixarArquivoAsync(string nomeArquivo) {
            byte[] buffer = _arquivoBusiness.PegarArquivo(nomeArquivo);
            if(buffer != null) {
                HttpContext.Response.ContentType = $"application/{Path.GetExtension(nomeArquivo).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                HttpContext.Response.Headers.Add("oi", "sss");
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }
            return new ContentResult();
        }

        [HttpPost("uploadArquivo")]
        [Produces("application/json")]
        public async Task<IActionResult> SalvarUmArquivo([FromForm] IFormFile arquivoUpload) {
            Arquivo arquivo = await _arquivoBusiness.SalvarArquivoDisco(arquivoUpload);
            return new OkObjectResult(arquivo);
        }

        [HttpPost("uploadVariosArquivos")]
        [Produces("application/json")]
        public async Task<IActionResult> SalvarVariosArquivos([FromForm] List<IFormFile> arquivoUpload) {
            List<Arquivo> arquivo = await _arquivoBusiness.SalvarMultiplosArquivosDisco(arquivoUpload);
            return new OkObjectResult(arquivo);
        }
    }
}
