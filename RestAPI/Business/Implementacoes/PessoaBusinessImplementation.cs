﻿using Microsoft.EntityFrameworkCore;
using RestAPI.Model;
using RestAPI.Repository;
using RestAPI.Repository.Generic;

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