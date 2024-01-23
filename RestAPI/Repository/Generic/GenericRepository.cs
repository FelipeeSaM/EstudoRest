using RestAPI.Model.Base;

namespace RestAPI.Repository.Generic {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel{
        public T Atualizar(T item) {
            throw new NotImplementedException();
        }

        public T BuscarPorId(int id) {
            throw new NotImplementedException();
        }

        public List<T> BuscarTodos() {
            throw new NotImplementedException();
        }

        public T Criar(T item) {
            throw new NotImplementedException();
        }

        public void Deletar(int id) {
            throw new NotImplementedException();
        }
    }
}
