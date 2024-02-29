using RestAPI.Hypermedia.Utils;
using RestAPI.Model;

namespace RestAPI.Business
{
    public interface IPessoaBusiness {
        Pessoa CriarPessoa(Pessoa pessoa);
        Pessoa ProcurarPorId(int id);
        List<Pessoa> ProcurarPorNome(string primeiroNome, string ultimoNome);
        List<Pessoa> ListarTodasPessoas();
        PagedSearch<Pessoa> ProcurarPaginado(string nome, string direcao, int tamanhoPagina, int pagina);
        Pessoa AtualizarPessoa(Pessoa pessoa);
        Pessoa AtivarOuDesativar(long id);
        void DeletarPessoa(int id);
    }
}
