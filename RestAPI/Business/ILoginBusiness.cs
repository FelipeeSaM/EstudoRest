using RestAPI.Data.DTO;

namespace RestAPI.Business {
    public interface ILoginBusiness {
        TokenDTO ValidateCredentials(UsersDTO user);
        TokenDTO ValidateCredentials(TokenDTO token);
        bool RevokeToken(string userName);
    }
}
