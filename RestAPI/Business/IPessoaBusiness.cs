using RestAPI.Model;

namespace RestAPI.Business
{
    public interface IPessoaBusiness {
        Pessoa CriarPessoa(Pessoa pessoa);
        Pessoa ProcurarPorId(int id);
        List<Pessoa> ListarTodasPessoas();
        Pessoa AtualizarPessoa(Pessoa pessoa);
        Pessoa AtivarOuDesativar(long id);
        void DeletarPessoa(int id);
    }
}
