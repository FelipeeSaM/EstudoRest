using RestAPI.Model;
using RestAPI.Model.Base;

namespace RestAPI.Repository.Generic {
    public interface IGenericRepository<T> where T : BaseModel {
        List<T> BuscarTodos();
        T BuscarPorId(int id);
        T Criar(T item);
        T Atualizar(T item);
        void Deletar(int id);
        List<T> ProcurarPaginacao(string query);
        int ReceberPaginacao(string query);
    }
}
