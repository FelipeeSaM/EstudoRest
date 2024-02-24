using RestAPI.Data.DTO;

namespace RestAPI.Business {
    public interface ILoginBusiness {
        TokenDTO ValidateCredentials(UsersDTO user);
    }
}
