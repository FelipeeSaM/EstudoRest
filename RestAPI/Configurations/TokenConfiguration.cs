namespace RestAPI.Configurations {
    public class TokenConfiguration {
        public string Audiencia { get; set; }
        public string Issuer { get; set; }
        public string Segredo { get; set; }
        public int Minutos { get; set; }
        public int DiasParaExpirar { get; set; }
    }
}
