using RestAPI.Model;
using RestAPI.Repository;

namespace RestAPI.Business.Implementacoes {
    public class LivroBusinessImplementation : ILivroBusiness {

        private readonly ILivrosRepository _context;

        public LivroBusinessImplementation(ILivrosRepository context) {
            _context = context;
        }

        public Livros BuscarLivroPorId(int id) {
            try {
                return _context.BuscarLivroPorId(id);
            }
            catch(Exception) {

                throw;
            }
        }

        public List<Livros> BuscarTodosLivros() {
            try {
                return _context.BuscarTodosLivros();
            }
            catch(Exception) {

                throw;
            }
        }

        public Livros AdicionarLivro(Livros livro) {
            try {
                return _context.CriarLivro(livro);
            }
            catch(Exception) {

                throw;
            }
        }

        public Livros AtualizarLivro(Livros livros) {
            try {
                return _context.AtualizarLivro(livros);
            }
            catch(Exception) {

                throw;
            }
        }

        public void DeletarLivro(int id) {
            try {
                _context.DeletarLivro(id);
            }
            catch(Exception) {

                throw;
            }
        }
    }
}
