using Microsoft.EntityFrameworkCore;
using RestAPI.Model;
using RestAPI.Model.Base;
using RestAPI.Model.restDbContext;

namespace RestAPI.Repository.Generic {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel{

        private readonly rest_api_db_context _context;
        
        private readonly DbSet<T> _dbSet;

        public GenericRepository(rest_api_db_context context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> BuscarTodos() {
            try {
                return _dbSet.ToList();
            }
            catch(Exception) {

                throw;
            }
        }

        public T BuscarPorId(int id) {
            try {
                return _dbSet.FirstOrDefault(c => c.Id.Equals(id));
            }
            catch(Exception) {

                throw;
            }
        }

        public T Criar(T item) {
            try {
                if(item != null) {
                    _dbSet.Add(item);
                    _context.SaveChanges();
                }
            }
            catch(Exception) {

                throw;
            }
            return item;
        }

        public T Atualizar(T item) {
            var resultado = _dbSet.SingleOrDefault(c => c.Id.Equals(item.Id));
            try {
                if(resultado != null) {
                    _dbSet.Entry(resultado).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
            }
            catch(Exception) {

                throw;
            }

            return item;
        }

        public void Deletar(int id) {
            try {
                var resultado = BuscarPorId(id);
                if(resultado != null) {
                    _dbSet.Remove(resultado);
                    _context.SaveChanges();
                }
            }
            catch(Exception) {

                throw;
            }
        }
    }
}
