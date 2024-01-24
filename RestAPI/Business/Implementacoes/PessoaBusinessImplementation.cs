using Microsoft.EntityFrameworkCore;
using RestAPI.Data.Converter.Implementations;
using RestAPI.Data.DTO;
using RestAPI.Model;
using RestAPI.Repository;
using RestAPI.Repository.Generic;

namespace RestAPI.Business.Implementacoes {
    public class PessoaBusinessImplementation : IPessoaBusiness {
        private readonly IGenericRepository<Pessoa> _repository;

        private readonly PersonConverter _personConverter;

        //Aqui vão as regras de negócio.
        public PessoaBusinessImplementation(IGenericRepository<Pessoa> context) {
            _repository = context;
            _personConverter = new PersonConverter();
        }
        
        public List<PessoaDTO> ListarTodasPessoas() {
            var retorno = _personConverter.Converter(_repository.BuscarTodos());
            return retorno;
        }

        public PessoaDTO ProcurarPorId(int id) {
            return _personConverter.Converter(_repository.BuscarPorId(id));
        }

        public PessoaDTO CriarPessoa(PessoaDTO pessoa) {
            try {
                var pessoaDTO = _personConverter.Converter(pessoa);
                pessoaDTO = _repository.Criar(pessoaDTO);
                return _personConverter.Converter(pessoaDTO);
            } catch (Exception) {
                throw;
            }
            return pessoa;
        }

        public PessoaDTO AtualizarPessoa(PessoaDTO pessoa) {
            try {
                var pessoaDTO = _personConverter.Converter(pessoa);
                pessoaDTO = _repository.Atualizar(pessoaDTO);
                return _personConverter.Converter(pessoaDTO);
            }
            catch(Exception) {
                throw;
            }
            return pessoa;
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