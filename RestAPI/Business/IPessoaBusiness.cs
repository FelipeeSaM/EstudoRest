using RestAPI.Data.DTO;

namespace RestAPI.Business
{
    public interface IPessoaBusiness {
        PessoaDTO CriarPessoa(PessoaDTO pessoa);
        PessoaDTO ProcurarPorId(int id);
        List<PessoaDTO> ListarTodasPessoas();
        PessoaDTO AtualizarPessoa(PessoaDTO pessoa);
        void DeletarPessoa(int id);
    }
}
