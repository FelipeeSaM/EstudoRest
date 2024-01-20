using RestAPI.Model;

namespace RestAPI.Repository {
    public interface IPessoaRepository {
        Pessoa CriarPessoa(Pessoa pessoa);
        Pessoa ProcurarPorId(int id);
        List<Pessoa> ListarTodasPessoas();
        Pessoa AtualizarPessoa(Pessoa pessoa);
        void DeletarPessoa(int id);
        bool Existe(int id);
    }
}
