using RestAPI.Model;

namespace RestAPI.Business {
    public interface IArquivoBusiness {
        public byte[] PegarArquivo(string arquivonome);
        public Task<Arquivo> SalvarArquivoDisco(IFormFile arquivo);
        public Task<List<Arquivo>> SalvarMultiplosArquivosDisco(IList<IFormFile> arquivos);
    }
}
