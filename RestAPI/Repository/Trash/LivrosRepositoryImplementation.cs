using RestAPI.Model;
using RestAPI.Model.restDbContext;

namespace RestAPI.Repository.Implementacoes {
    public class LivrosRepositoryImplementation : ILivrosRepository {

        private readonly rest_api_db_context _dbContext;

        public LivrosRepositoryImplementation(rest_api_db_context contexto) {
            _dbContext = contexto;
        }

        public Livros BuscarLivroPorId(int id) {
            try {
                return _dbContext.livros.FirstOrDefault(c => c.Id.Equals(id));
            }
            catch(Exception ex) {

                throw;
            }
        }

        public List<Livros> BuscarTodosLivros() {
            try {
                return _dbContext.livros.ToList();
            }
            catch(Exception ex) {

                throw;
            }
        }

        public Livros CriarLivro(Livros livro) {
            try {
                if(BuscarLivroPorId(livro.Id) == null) {
                    _dbContext.livros.Add(livro);
                    _dbContext.SaveChanges();
                }
            }
            catch(Exception) {

                throw;
            }
            return livro;
        }

        public Livros AtualizarLivro(Livros livro) {
            try {
                if(BuscarLivroPorId(livro.Id) != null) {
                    var addLivro = livro;
                    _dbContext.Entry(livro).CurrentValues.SetValues(livro);
                    _dbContext.SaveChanges();
                }
            }
            catch(Exception) {

                throw;
            }
            return livro;
        }

        public void DeletarLivro(int id) {
            try {
                Livros livro = BuscarLivroPorId(id);
                if(livro != null)
                    _dbContext.livros.Remove(livro);
                    _dbContext.SaveChanges();
            }
            catch(Exception) {

                throw;
            }
        }
    }
}
