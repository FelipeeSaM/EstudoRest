using RestAPI.Data.DTO;
using RestAPI.Model;

namespace RestAPI.Repository {
    public interface IUserRepository {
        Users ValidateCredentials(UsersDTO user);
    }
}
