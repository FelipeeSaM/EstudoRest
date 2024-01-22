using RestAPI.Model;
using RestAPI.Repository;

namespace RestAPI.Business.Implementacoes {
    public class PessoaBusinessImplementation : IPessoaBusiness {
        private readonly IPessoaRepository _repository;
        //Aqui vão as regras de negócio.
        public PessoaBusinessImplementation(IPessoaRepository context)
        {
            _repository = context;
        }
        
        public List<Pessoa> ListarTodasPessoas() {
            var retorno = _repository.ListarTodasPessoas();
            return retorno;
        }

        public Pessoa ProcurarPorId(int id) {
            return _repository.ProcurarPorId(id);
        }

        public Pessoa CriarPessoa(Pessoa pessoa) {
            try {
                // Um exemplo de regra de negócio criada
                if(pessoa.Genero == "masc") {
                    _repository.CriarPessoa(pessoa);
                }
            } catch (Exception) {
                throw;
            }
            return pessoa;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa) {
            try {
                if(pessoa.Endereco == "Brasil") {
                    _repository.AtualizarPessoa(pessoa);
                }
            }
            catch(Exception) {
                throw;
            }
            return pessoa;
        }

        public void DeletarPessoa(int id) {
            try {
                _repository.DeletarPessoa(id);
            }
            catch(Exception) {
                throw;
            }
        }

    }
}