using RestAPI.Model;

namespace RestAPI.Servicos.Implementacoes {
    public class PessoaServiceImplementation : IPessoaService {
        private volatile int contador;

        public Pessoa CriarPessoa(Pessoa pessoa) {
            return pessoa;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa) {
            return pessoa;
        }

        public void DeletarPessoa(long id) {
            
        }

        public List<Pessoa> ListarTodasPessoas() {
            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 8; i++) {
                Pessoa pessoaLista = MockPessoa(i);
                pessoas.Add(pessoaLista);
            }
            return pessoas;
        }

        public Pessoa ProcurarPorId(long id) {
            return new Pessoa() { Id = Incrementar(), PrimeiroNome = "o cara", UltimoNome = "isso ai", Endereco = "logo ali", Genero = "m" };
        }

        private Pessoa MockPessoa(int i) {
            return new Pessoa() {
                Id = Incrementar(),
                PrimeiroNome = "Pessoa" + i,
                UltimoNome = "adsadas" + i,
                Endereco = "aaaaaa" + i,
                Genero = "m" 
            };
        }

        private long Incrementar() {
            return Interlocked.Increment(ref contador);
        }
    }
}
