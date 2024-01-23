using RestAPI.Model;
using RestAPI.Repository;
using RestAPI.Repository.Generic;

namespace RestAPI.Business.Implementacoes {
    public class LivroBusinessImplementation : ILivroBusiness {

        private readonly IGenericRepository<Livros> _context;

        public LivroBusinessImplementation(IGenericRepository<Livros> context) {
            _context = context;
        }

        public Livros BuscarLivroPorId(int id) {
            try {
                return _context.BuscarPorId(id);
            }
            catch(Exception) {

                throw;
            }
        }

        public List<Livros> BuscarTodosLivros() {
            try {
                return _context.BuscarTodos();
            }
            catch(Exception) {

                throw;
            }
        }

        public Livros AdicionarLivro(Livros livro) {
            try {
                return _context.Criar(livro);
            }
            catch(Exception) {

                throw;
            }
        }

        public Livros AtualizarLivro(Livros livros) {
            try {
                return _context.Atualizar(livros);
            }
            catch(Exception) {

                throw;
            }
        }

        public void DeletarLivro(int id) {
            try {
                _context.Deletar(id);
            }
            catch(Exception) {

                throw;
            }
        }
    }
}
