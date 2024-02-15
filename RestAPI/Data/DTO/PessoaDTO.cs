using RestAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Data.DTO {
    public class PessoaDTO {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
    }
}