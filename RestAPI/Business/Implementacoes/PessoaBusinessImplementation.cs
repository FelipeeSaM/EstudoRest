using Microsoft.EntityFrameworkCore;
using RestAPI.Hypermedia.Utils;
using RestAPI.Model;
using RestAPI.Repository;
using RestAPI.Repository.Generic;
using System.Drawing.Printing;

namespace RestAPI.Business.Implementacoes {
    public class PessoaBusinessImplementation : IPessoaBusiness {
        private readonly IPessoaRepository _repository;

        //Aqui vão as regras de negócio.
        public PessoaBusinessImplementation(IPessoaRepository context) {
            _repository = context;
        }
        
        public List<Pessoa> ListarTodasPessoas() {
            var retorno = _repository.BuscarTodos();
            return retorno;
        }

        public Pessoa ProcurarPorId(int id) {
            return _repository.BuscarPorId(id);
        }

        public List<Pessoa> ProcurarPorNome(string primeiroNome, string ultimoNome) {
            var retorno = _repository.PesquisarPorNome(primeiroNome, ultimoNome);
            return retorno;
        }

        public PagedSearch<Pessoa> ProcurarPaginado(string name, string direcao, int tamanhoPagina, int pagina) {
            var sort = (!string.IsNullOrWhiteSpace(direcao) && !direcao.Equals("desc")) ? "asc" : "desc";
            var size = tamanhoPagina < 1 ? 10 : tamanhoPagina;
            var offset = pagina > 0 ? (pagina - 1) * size : 0;

            string query = BuildQuery(name, sort, size, offset);
            string countQuery = BuildCountQuery(name);

            var persons = _repository.ProcurarPaginacao(query);
            int totalResults = _repository.ReceberPaginacao(countQuery);

            return new PagedSearch<Pessoa> {
                CurrentPage = pagina,
                List = persons,
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        private string BuildQuery(string name, string sort, int size, int offset) {
            return $@"select * from pessoas p where 1 = 1 
                {(string.IsNullOrWhiteSpace(name) ? "" : $"and p.PrimeiroNome like '%{name}%'")}
                order by p.PrimeiroNome {sort} 
                offset {offset} ROWS FETCH NEXT {size} ROWS ONLY";
        }

        private string BuildCountQuery(string name) {
            return $@"select count(*) from pessoas p where 1 = 1 
              {(string.IsNullOrWhiteSpace(name) ? "" : $"and p.PrimeiroNome like '%{name}%'")}";
        }

        public Pessoa CriarPessoa(Pessoa pessoa) {
            try {
                // Um exemplo de regra de negócio criada
                if(pessoa.Genero == "masc") {
                    _repository.Criar(pessoa);
                }
            } catch (Exception) {
                throw;
            }
            return pessoa;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa) {
            try {
                if(pessoa.Endereco == "Brasil") {
                    _repository.Atualizar(pessoa);
                }
            }
            catch(Exception) {
                throw;
            }
            return pessoa;
        }

        public Pessoa AtivarOuDesativar(long id) {
            var operacao = _repository.AtivarOuDesativar(id);
            return operacao;
        }

        public void DeletarPessoa(int id) {
            try {
                _repository.Deletar(id);
            }
            catch(Exception) {
                throw;
            }
        }
    }
}