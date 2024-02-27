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
    }
}
