using Microsoft.EntityFrameworkCore;
using RestAPI.Data.DTO;
using RestAPI.Model;
using RestAPI.Model.restDbContext;
using System.Security.Cryptography;
using System.Text;

namespace RestAPI.Repository {
    public class UserRepository : IUserRepository {

        private readonly rest_api_db_context _context;

        public UserRepository(rest_api_db_context context) {
            _context = context;
        }

        public Users? ValidateCredentials(UsersDTO user) {
            var pass = ComputeHash(user.Password, SHA256.Create());
            return _context.users.FirstOrDefault(c => (c.UserName == user.UserName) && (c.Password == pass));
        }

        public Users? ValidateCredentials(string userName) {
            return _context.users.SingleOrDefault(c => (c.UserName == userName));
        }

        public bool RevokeToken(string userName) {
            var user = _context.users.SingleOrDefault(c => c.UserName == userName);
            if(user == null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public Users? AtualizarInfoUsuario(Users user) {

            if(!_context.users.Any(c => c.Id.Equals(user.Id))) return null;

            var resultado = _context.users.SingleOrDefault(c => c.Id.Equals(user.Id));
            try {
                if(resultado != null) {
                    _context.Entry(resultado).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
            }
            catch(Exception) {

                throw;
            }

            return resultado;
        }

        private string ComputeHash(string input, HashAlgorithm algoritmo) {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algoritmo.ComputeHash(inputBytes);

            var builder = new StringBuilder();
            foreach(var item in hashedBytes) {
                builder.Append(item.ToString("x2"));
            }

            return BitConverter.ToString(hashedBytes);
        }

    }
}
