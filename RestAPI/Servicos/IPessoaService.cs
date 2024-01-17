using RestAPI.Model;

namespace RestAPI.Servicos
{
    public interface IPessoaService
    {
        Pessoa CriarPessoa(Pessoa pessoa);
        Pessoa ProcurarPorId(int id);
        List<Pessoa> ListarTodasPessoas();
        Pessoa AtualizarPessoa(Pessoa pessoa);
        void DeletarPessoa(int id);
    }
}
