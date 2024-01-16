using RestAPI.Model;

namespace RestAPI.Servicos
{
    public interface IPessoaService
    {
        Pessoa CriarPessoa(Pessoa pessoa);
        Pessoa ProcurarPorId(long id);
        List<Pessoa> ListarTodasPessoas();
        Pessoa AtualizarPessoa(Pessoa pessoa);
        void DeletarPessoa(long id);
    }
}
