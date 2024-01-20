using RestAPI.Model;
using RestAPI.Model.restDbContext;

namespace RestAPI.Repository.Implementacoes {
    public class PessoaRepositoryImplementation : IPessoaRepository {
        public rest_api_db_context _context;

        public PessoaRepositoryImplementation(rest_api_db_context contexto)
        {
            _context = contexto;
        }

        public List<Pessoa> ListarTodasPessoas() {
            return _context.pessoas.ToList();
        }

        public Pessoa ProcurarPorId(int id) {
            return _context.pessoas.SingleOrDefault(c => c.Id.Equals(id));
        }

        public Pessoa CriarPessoa(Pessoa pessoa) {
            try {
                _context.Add(pessoa);
                _context.SaveChanges();
            } catch (Exception) {
                throw;
            }
            return pessoa;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa) {
            try {
                Pessoa pessoa1 = ProcurarPorId(pessoa.Id);
                if(pessoa1 != null) {
                    _context.Entry(pessoa1).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
            }
            catch(Exception) {
                throw;
            }
            return pessoa;
        }

        public void DeletarPessoa(int id) {
            try {
                Pessoa pessoa1 = ProcurarPorId(id);
                if(pessoa1 != null) {
                    _context.pessoas.Remove(pessoa1);
                    _context.SaveChanges();
                }
            }
            catch(Exception) {
                throw;
            }
        }

        public bool Existe(int id) {
            return _context.pessoas.Any(c => c.Id.Equals(id));
        }

    }
}