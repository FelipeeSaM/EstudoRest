using RestAPI.Model;
using RestAPI.Repository.Generic;

namespace RestAPI.Repository {
    public interface IPessoaRepository : IGenericRepository<Pessoa> {
        Pessoa AtivarOuDesativar(long id);
        List<Pessoa> PesquisarPorNome(string primeiroNome, string ultimoNome);
    }
}
