using System.Security.Claims;

namespace RestAPI.Configurations.ServicesToken {
    public interface ITokenService {
        string GenerateAcessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
