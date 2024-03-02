using RestAPI.Model;

namespace RestAPI.Business.Implementacoes {
    public class ArquivoBusinessImplementation : IArquivoBusiness {

        private readonly string caminhoArquivo;
        private readonly IHttpContextAccessor _httpContext;

        public ArquivoBusinessImplementation(IHttpContextAccessor httpContext) {
            _httpContext = httpContext;
            caminhoArquivo = Directory.GetCurrentDirectory() + "\\Arquivos\\";
        }

        public byte[] PegarArquivo(string arquivonome) {
            var caminho = caminhoArquivo + arquivonome;
            return File.ReadAllBytes(caminho);
        }

        public async Task<Arquivo> SalvarArquivoDisco(IFormFile arquivo) {
            Arquivo arquivoDetalhes = new Arquivo();

            var arquivoTipo = Path.GetExtension(arquivo.FileName);
            var baseUrl = _httpContext.HttpContext.Request.Host;

            if(arquivoTipo.ToLower() == ".pdf" || arquivoTipo.ToLower() == ".jpg" || 
                arquivoTipo.ToLower() == ".png" || arquivoTipo.ToLower() == ".jpeg" ||
                arquivoTipo.ToLower() == ".jpg") {

                var arquivoNome = Path.GetFileName(arquivo.FileName);
                if(arquivo != null && arquivo.Length > 0) {
                    var destino = Path.Combine(caminhoArquivo, "", arquivoNome);
                    arquivoDetalhes.DocumentoNome = arquivoNome;
                    arquivoDetalhes.DocumentoTipo = arquivoTipo;
                    arquivoDetalhes.DocumentoUrl = Path.Combine(baseUrl + "/api/v1/arquivo/" + arquivoDetalhes.DocumentoNome);

                    using var stream = new FileStream(destino, FileMode.Create);
                    await arquivo.CopyToAsync(stream);
                }
            }
            return arquivoDetalhes;
        }

        public async Task<List<Arquivo>> SalvarMultiplosArquivosDisco(IList<IFormFile> arquivos) {
            List<Arquivo> listaArquivos = new List<Arquivo>();

            foreach(var arquivo in arquivos) {
                listaArquivos.Add(await SalvarArquivoDisco(arquivo));
            }

            return listaArquivos;
        }
    }
}
