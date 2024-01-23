using RestAPI.Model;

namespace RestAPI.Repository {
    public interface ILivrosRepository {
        List<Livros> BuscarTodosLivros();
        Livros BuscarLivroPorId(int id);
        Livros CriarLivro(Livros livros);
        Livros AtualizarLivro(Livros livro);
        void DeletarLivro(int id);
    }
}
