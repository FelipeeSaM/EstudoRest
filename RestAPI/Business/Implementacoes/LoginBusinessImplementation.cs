using RestAPI.Configurations;
using RestAPI.Configurations.ServicesToken;
using RestAPI.Data.DTO;
using RestAPI.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestAPI.Business.Implementacoes {
    public class LoginBusinessImplementation : ILoginBusiness {

        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService) {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenDTO ValidateCredentials(UsersDTO userCredentials) {
            var user = _repository.ValidateCredentials(userCredentials);
            if(user == null) return null;

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var acessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DiasParaExpirar);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutos);

            _repository.AtualizarInfoUsuario(user);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
                );
        }
    }
}
