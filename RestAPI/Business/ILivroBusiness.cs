using RestAPI.Model;

namespace RestAPI.Business {
    public interface ILivroBusiness {
        List<Livros> BuscarTodosLivros();
        Livros BuscarLivroPorId(int id);
        Livros AdicionarLivro(Livros livro);
        Livros AtualizarLivro(Livros livros);
        void DeletarLivro(int id);
    }
}
