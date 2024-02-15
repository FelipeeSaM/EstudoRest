using Microsoft.CodeAnalysis.CSharp.Syntax;
using RestAPI.Data.Converter.Contract;
using RestAPI.Data.DTO;
using RestAPI.Model;

namespace RestAPI.Data.Converter.Implementations {
    public class PersonConverter : IConverter<PessoaDTO, Pessoa>, IConverter<Pessoa, PessoaDTO> {

        /// <summary>
        /// Faz o parse de Person para PersonDTO
        /// </summary>
        /// <param name="origem"></param>
        /// <returns>Retorna o DTO específico</returns>
        /// <exception cref="NotImplementedException"></exception>
        public PessoaDTO Converter(Pessoa origem) {

            if(origem == null) {
                return null;
            }

            return new PessoaDTO {
                Id = origem.Id,
                PrimeiroNome = origem.PrimeiroNome,
                UltimoNome = origem.UltimoNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero,
            };

        }

        public List<PessoaDTO> Converter(List<Pessoa> origem) {
            if(origem == null) {
                return null;
            }
            return origem.Select(item => Converter(item)).ToList();
        }


        /// <summary>
        /// Faz o parse de PessoaDTO para Pessoa
        /// </summary>
        /// <param name="origem"></param>
        /// <returns>Objeto do tipo Pessoa</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Pessoa Converter(PessoaDTO origem) {
            if(origem == null) {
                return null;
            }

            return new Pessoa {
                Id = origem.Id,
                PrimeiroNome = origem.PrimeiroNome,
                UltimoNome = origem.UltimoNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero,
            };

        }

        public List<Pessoa> Converter(List<PessoaDTO> origem) {
            if(origem == null) {
                return null;
            }
            return origem.Select(item => Converter(item)).ToList();
        }

    }
}