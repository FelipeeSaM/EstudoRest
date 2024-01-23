using RestAPI.Model;
using RestAPI.Model.Base;

namespace RestAPI.Repository.Generic {
    public interface IGenericRepository<T> where T : BaseModel {
        List<T> BuscarTodos();
        T BuscarPorId(int id);
        T Criar(T livros);
        T Atualizar(T livro);
        void Deletar(int id);
    }
}
