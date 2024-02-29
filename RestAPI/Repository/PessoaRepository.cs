using RestAPI.Model;
using RestAPI.Model.restDbContext;
using RestAPI.Repository.Generic;

namespace RestAPI.Repository {
    public class PessoaRepository : GenericRepository<Pessoa>, IPessoaRepository {
        public PessoaRepository(rest_api_db_context context) : base(context) { }

        public Pessoa AtivarOuDesativar(long id) {
            if(!_context.pessoas.Any(c => c.Id.Equals(id))) return null;
            var usuario = _context.pessoas.SingleOrDefault(c => c.Id.Equals(id));
            if(usuario != null) {
                usuario.Ativo = false;
                try {
                    _context.pessoas.Entry(usuario).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();
                }
                catch(Exception) {

                    throw;
                }
            }
            return usuario;
        }

        public List<Pessoa> PesquisarPorNome(string primeiroNome, string ultimoNome) {
            if(!string.IsNullOrWhiteSpace(primeiroNome) || !string.IsNullOrWhiteSpace(ultimoNome)) {
                return _context.pessoas
                    .Where(c =>
                        (string.IsNullOrWhiteSpace(primeiroNome) || c.PrimeiroNome.Contains(primeiroNome)) &&
                        (string.IsNullOrWhiteSpace(ultimoNome) || c.UltimoNome.Contains(ultimoNome))).ToList();
            }
            return null;
        }
    }
}
