namespace RestAPI.Data.DTO {
    public class TokenDTO {
        public TokenDTO(bool autenticado, string criado, string expiracao, string tokenAcesso, string refreshToken) {
            Autenticado = autenticado;
            Criado = criado;
            Expiracao = expiracao;
            TokenAcesso = tokenAcesso;
            RefreshToken = refreshToken;
        }

        public bool Autenticado { get; set; }
        public string Criado { get; set; }
        public string Expiracao { get; set; }
        public string TokenAcesso { get; set; }
        public string RefreshToken { get; set; }
    }
}
